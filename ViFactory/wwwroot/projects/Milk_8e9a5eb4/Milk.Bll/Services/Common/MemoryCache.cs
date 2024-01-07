using Microsoft.Extensions.Caching.Memory;
using Milk.Core.Services;


namespace Milk.Bll.Services.Common
{
     public class MemoryCacheService : IMemoryCacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly PostEvictionDelegate BeforeHashRemove;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;

            BeforeHashRemove = (_key, value, reason, state) =>
            {
                switch (reason)
                {
                    case EvictionReason.Replaced:
                        return;
                    case EvictionReason.Expired:
                        {
                            var expire = GetExpireFromHashIds(_key.ToString()!);

                            if (expire != null && expire <= DateTimeOffset.Now)
                                RemoveFromHashIds(_key.ToString()!);
                        }
                        break;
                    default:
                        RemoveFromHashIds(_key.ToString()!);
                        break;
                }
            };
        }

        #region strings-data
        public T Set<T>(string hashId, T data, DateTimeOffset? expiration)
        {
            var options = new MemoryCacheEntryOptions();

            options.Priority = CacheItemPriority.NeverRemove;

            options.AbsoluteExpiration = expiration;

            options.RegisterPostEvictionCallback(BeforeHashRemove);

            AddToHashIds(hashId, options.AbsoluteExpiration);

            return _memoryCache.Set(hashId, data, options);
        }

        public T? Get<T>(string hashId)
        {
            return _memoryCache.Get<T>(hashId);
        }
        #endregion

        #region list
        public LinkedList<T> Lpush<T>(string hashId, T data, DateTimeOffset? expiration)
        {
            LinkedList<T> list = Get<LinkedList<T>>(hashId) ?? new LinkedList<T>();

            list.AddFirst(data);

            return Set(hashId, list, expiration);
        }

        public LinkedList<T> Rpush<T>(string hashId, T data, DateTimeOffset? expiration)
        {
            LinkedList<T> list = Get<LinkedList<T>>(hashId) ?? new LinkedList<T>();

            list.AddLast(data);

            return Set(hashId, list, expiration);
        }

        public List<T>? Lrange<T>(string hashId, int skip, int take)
        {
            return take > -1 ? Get<LinkedList<T>>(hashId)?.Skip(skip).Take(take).ToList() : Get<LinkedList<T>>(hashId)?.Skip(skip).ToList();
        }

        public T? Lpop<T>(string hashId, DateTimeOffset? expiration)
        {
            LinkedList<T>? list = Get<LinkedList<T>>(hashId);

            if (list == null)
                return default;

            var result = list.First!.Value;

            list.RemoveFirst();

            if (list.Count > 0)
                Set(hashId, list, expiration);
            else
                Remove(hashId);

            return result;
        }

        public T? Rpop<T>(string hashId, DateTimeOffset? expiration)
        {
            LinkedList<T>? list = Get<LinkedList<T>>(hashId);

            if (list == null)
                return default;

            var result = list.Last!.Value;

            list.RemoveLast();

            if (list.Count > 0)
                Set(hashId, list, expiration);
            else
                Remove(hashId);

            return result;
        }
        #endregion

        #region set
        public HashSet<T> Sadd<T>(string hashId, T data, DateTimeOffset? expiration)
        {
            HashSet<T> set = Get<HashSet<T>>(hashId) ?? new HashSet<T>();

            set.Add(data);

            return Set(hashId, set, expiration);
        }

        public HashSet<T>? Smembers<T>(string hashId)
        {
            return Get<HashSet<T>>(hashId);
        }

        public void Srem<T>(string hashId, T data, DateTimeOffset? expiration)
        {
            HashSet<T> set = Get<HashSet<T>>(hashId) ?? new HashSet<T>();

            if (set == null)
                return;

            set.Remove(data);

            if (set.Count > 0)
                Set(hashId, set, expiration);
            else
                Remove(hashId);
        }
        #endregion

        #region hash
        public Dictionary<string, T> Hset<T>(string hashId, string key, T data, DateTimeOffset? expiration)
        {
            var set = Get<Dictionary<string, T>>(hashId) ?? new Dictionary<string, T>();

            set[key] = data;

            return Set(hashId, set, expiration);
        }

        public T? Hget<T>(string hashId, string key)
        {
            var set = Get<Dictionary<string, T>>(hashId);

            if (set == null)
                return default;

            return set![key];
        }

        public Dictionary<string, T>? Hgetall<T>(string hashId)
        {
            return Get<Dictionary<string, T>>(hashId);
        }

        public void Hdel<T>(string hashId, string key, DateTimeOffset? expiration)
        {
            var set = Get<Dictionary<string, T>>(hashId);

            if (set == null)
                return;

            set!.Remove(key);

            if (set.Count > 0)
                Set(hashId, set, expiration);
            else
                Remove(hashId);
        }
        #endregion

        #region sortedSet
        public List<KeyValuePair<int, T>> Zadd<T>(string hashId, int score, T data, DateTimeOffset? expiration)
        {
            var set = Get<List<KeyValuePair<int, T>>>(hashId) ?? new List<KeyValuePair<int, T>>();

            set.Add(new KeyValuePair<int, T>(score, data));

            return Set(hashId, set, expiration);
        }

        public List<KeyValuePair<int, T>>? Zrange<T>(string hashId, int skip, int take)
        {
            return take > -1 ? Get<List<KeyValuePair<int, T>>>(hashId)?.Skip(skip).Take(take).ToList() : Get<List<KeyValuePair<int, T>>>(hashId)?.Skip(skip).ToList();
        }

        public List<KeyValuePair<int, T>>? Zrangebyscore<T>(string hashId, int minscore, int maxscore)
        {
            return Get<List<KeyValuePair<int, T>>>(hashId)?.Where(x => minscore <= x.Key && x.Key <= maxscore).OrderBy(x => x.Key).ToList();
        }

        public void Zrem<T>(string hashId, KeyValuePair<int, T> data, DateTimeOffset? expiration)
        {
            var set = Get<List<KeyValuePair<int, T>>>(hashId);

            if (set == null)
                return;

            set.Remove(data);

            if (set.Count > 0)
                Set(hashId, set, expiration);
            else
                Remove(hashId);
        }
        #endregion

        #region hashId storage
        public void AddToHashIds(string hashId, DateTimeOffset? expire)
        {
            var set = Get<Dictionary<string, DateTimeOffset?>>("_hashIds") ?? new Dictionary<string, DateTimeOffset?>();

            set[hashId] = expire;

            _memoryCache.Set("_hashIds", set, new MemoryCacheEntryOptions
            {
                Priority = CacheItemPriority.NeverRemove
            });
        }

        public void RemoveFromHashIds(string hashId)
        {
            var set = Get<Dictionary<string, DateTimeOffset?>>("_hashIds");

            if (set == null)
                return;

            set.Remove(hashId);

            if (set.Count > 0)
                _memoryCache.Set("_hashIds", set);
            else
                Remove("_hashIds");
        }

        public DateTimeOffset? GetExpireFromHashIds(string hashId)
        {
            var set = Get<Dictionary<string, DateTimeOffset?>>("_hashIds");

            return set?[hashId];
        }
        #endregion

        public void Remove(string hashId)
        {
            _memoryCache.Remove(hashId);
        }

        public void Flushall()
        {
            var hashIds = Hgetall<DateTimeOffset?>("_hashIds");

            if (hashIds != null)
            {
                foreach (var hashId in hashIds.Keys)
                    Remove(hashId);
            }
        }
    }
}