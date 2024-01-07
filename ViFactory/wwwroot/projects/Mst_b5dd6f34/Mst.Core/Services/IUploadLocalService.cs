using System.Linq.Expressions;
using Mst.Core.Models;
using Mst.Core.Models.RepositoryModels;
using Mst.Core.RepositoryModels;
using Microsoft.AspNetCore.Http;

namespace Mst.Core.Core.Services
{
   /// <summary>
    /// common upload file service
    /// </summary>
    /// <param name="file"></param>
    /// <param name="folderPath"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="quality"></param>
    /// <param name="isPrivate"></param>
    /// <returns></returns>
    public interface IUploadLocalService
    {
        Task<List<string>> MultiUpload(List<IFormFile> files, string folderPath, int? width = null, int? height = null, int? quality = 100, bool isPrivate = false);
        Task<string> Upload(IFormFile file, string folderPath, int? width = null, int? height = null, int? quality = 100, bool isPrivate = false);
        Task<string> Upload(string file, string folderPath, int? width = null, int? height = null, int? quality = 100, bool isPrivate = false);
        void Remove(string filePath);
    }
}


