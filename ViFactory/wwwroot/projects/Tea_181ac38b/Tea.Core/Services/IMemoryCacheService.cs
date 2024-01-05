namespace Tea.Core.Services
{
    public interface IMemoryCacheService
    {
        /// <summary>
        /// keep hashIds
        /// </summary>
        /// <param name="hashId"></param>
        /// <param name="expire"></param>
        void AddToHashIds(string hashId, DateTimeOffset? expire);

        /// <summary>
        /// remove all cache
        /// </summary>
        void Flushall();

        T? Get<T>(string hashId);
        DateTimeOffset? GetExpireFromHashIds(string hashId);
        void Hdel<T>(string hashId, string key, DateTimeOffset? expiration);
        T? Hget<T>(string hashId, string key);
        Dictionary<string, T>? Hgetall<T>(string hashId);
        Dictionary<string, T> Hset<T>(string hashId, string key, T data, DateTimeOffset? expiration);
        T? Lpop<T>(string hashId, DateTimeOffset? expiration);
        LinkedList<T> Lpush<T>(string hashId, T data, DateTimeOffset? expiration);
        List<T>? Lrange<T>(string hashId, int skip, int take);
        void Remove(string hashId);
        void RemoveFromHashIds(string hashId);
        T? Rpop<T>(string hashId, DateTimeOffset? expiration);
        LinkedList<T> Rpush<T>(string hashId, T data, DateTimeOffset? expiration);
        HashSet<T> Sadd<T>(string hashId, T data, DateTimeOffset? expiration);
        T Set<T>(string hashId, T data, DateTimeOffset? expiration);
        HashSet<T>? Smembers<T>(string hashId);
        void Srem<T>(string hashId, T data, DateTimeOffset? expiration);
        List<KeyValuePair<int, T>> Zadd<T>(string hashId, int score, T data, DateTimeOffset? expiration);
        List<KeyValuePair<int, T>>? Zrange<T>(string hashId, int skip, int take);
        List<KeyValuePair<int, T>>? Zrangebyscore<T>(string hashId, int minscore, int maxscore);
        void Zrem<T>(string hashId, KeyValuePair<int, T> data, DateTimeOffset? expiration);
    }
}


