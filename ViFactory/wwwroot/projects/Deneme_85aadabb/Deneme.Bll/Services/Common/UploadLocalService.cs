using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using System.Net;
using Deneme.Bll.Models;
using Deneme.Core.Services;

namespace Deneme.Bll.Services.Common
{
    public class UploadLocalService : IUploadLocalService
    {
       private readonly string[] supportedMimeTypes = {
       "image/jpeg",
       "image/png",
       "image/gif",
       "application/pdf",
       "application/msword",
       "application/vnd.openxmlfo-officedocument.wordprocessingml.document",
       "application/vnd.ms-excel",
       "application/vnd.openxmlfo-officedocument.spreadsheetml.sheet"

     };
            private readonly string _basePublicFolderPath;
            private readonly string _basePrivateFolderPath;

            public UploadLocalService(string basePublicFolderPath, string basePrivateFolderPath)
            {
                _basePrivateFolderPath = basePrivateFolderPath;
                _basePublicFolderPath = basePublicFolderPath;
            }

            public async Task<List<string>> MultiUploadAsync(IEnumerable<IFormFile> files, string folderPath, int? width = null, int? height = null, int? quality = 100, bool isPrivate = false)
            {
                var result = new List<string>();

                foreach (var image in files.Where(x => x is not null))
                {
                    var imageUrl = await UploadAsnyc(image, folderPath, width, height, quality, isPrivate);

                    result.Add(imageUrl);
                }

                return result;
            }

            public async Task<List<string>> MultiUploadAsync(IEnumerable<string> base64Files, string folderPath, int? width = null, int? height = null, int? quality = 100, bool isPrivate = false)
            {
                var result = new List<string>();

                foreach (var file in base64Files.Where(x => x is not null))
                {
                    var imageUrl = await UploadAsync(file, folderPath, width, height, quality, isPrivate);

                    result.Add(imageUrl);
                }

                return result;
            }

            public Task<string> UploadAsnyc(IFormFile file, string folderPath, int? width = null, int? height = null, int? quality = 100, bool isPrivate = false)
            {
                if (!supportedMimeTypes.Contains(file.ContentType))
                    throw new ResponseException(HttpStatusCode.UnsupportedMediaType, Enums.ExceptionResponseType.UnsupportedMediaType, new Exception($"Unsupported media type {file.ContentType} for UploadService"));

                return UploadAsync(ConvertIFormFileToBase64(file), folderPath, width, height, quality, isPrivate);
            }

            public async Task<string> UploadAsync(string base64, string folderPath, int? width = null, int? height = null, int? quality = 100, bool isPrivate = false)
            {
                var baseFolder = Path.Combine(isPrivate ? _basePrivateFolderPath : _basePublicFolderPath, folderPath);

                CreateFolderIfNotExist(baseFolder);

                var fileName = GetFileName(base64);

                var filePath = Path.Combine(baseFolder, fileName).ToLower();

                var byteArray = Convert.FromBase64String(base64.Substring(base64.IndexOf(',') + 1));

                if (width.HasValue && height.HasValue && GetIsResizeable(base64))
                    byteArray = ResizeImage(base64, width!.Value, height!.Value, quality!.Value);

                await File.WriteAllBytesAsync(filePath, byteArray);

                return filePath.Substring(filePath.IndexOf("\\wwwroot\\") + "\\wwwroot".Length).Replace("\\", "/");
            }

            public void Remove(string filePath)
            {
                File.Delete(filePath);
            }

            private void CreateFolderIfNotExist(string folderPath)
            {
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);
            }

            private string ConvertIFormFileToBase64(IFormFile file)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    file.CopyTo(stream);

                    var byteArray = stream.ToArray();

                    var base64 = Convert.ToBase64String(byteArray);

                    var mimeType = file.ContentType;

                    if (string.IsNullOrEmpty(mimeType))
                        throw new ResponseException(HttpStatusCode.UnsupportedMediaType, Enums.ExceptionResponseType.UnsupportedMediaType, new Exception($"Unsupported media type {file.ContentType} for UploadService"));

                    return $"data:{mimeType};base64,{base64}";
                }
            }

            private string GetFileName(string base64)
            {
                return $"{Guid.NewGuid()}{GetExtensionFromMimeType(GetMimeTypeFromBase64(base64))}";
            }

            private string GetMimeTypeFromBase64(string base64)
            {
                var mimeType = base64.Substring(0, base64.IndexOf(';'));
                mimeType = mimeType.Substring(mimeType.IndexOf(':') + 1);

                if (!supportedMimeTypes.Contains(mimeType))
                    throw new ResponseException(HttpStatusCode.UnsupportedMediaType, Enums.ExceptionResponseType.UnsupportedMediaType, new Exception($"Unsupported media type {mimeType} for UploadService"));

                return mimeType;
            }

            private string GetExtensionFromMimeType(string mimeType)
            {
                if (!string.IsNullOrEmpty(mimeType))
                {
                    switch (mimeType)
                    {
                        case "image/jpeg":
                            return ".jpg";
                        case "image/png":
                            return ".png";
                        case "image/gif":
                            return ".gif";
                        case "application/pdf":
                            return ".pdf";
                        case "application/msword":
                            return ".doc";
                        case "application/vnd.openxmlformats-officedocument.wordprocessingml.document":
                            return ".docx";
                        case "application/vnd.ms-excel":
                            return ".xls";
                        case "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet":
                            return ".xlsx";
                        default:
                            throw new ResponseException(HttpStatusCode.UnsupportedMediaType, Enums.ExceptionResponseType.UnsupportedMediaType, new Exception($"Unsupported media type {mimeType} for UploadService"));
                    }
                }

                throw new ResponseException(HttpStatusCode.UnsupportedMediaType, Enums.ExceptionResponseType.UnsupportedMediaType, new Exception($"Unsupported media type {mimeType} for UploadService"));
            }

            private bool GetIsResizeable(string base64)
            {
                var mimeType = GetMimeTypeFromBase64(base64);

                return mimeType.StartsWith("image/");
            }

            private byte[] ResizeImage(string base64, int width, int height, int quality)
            {
                var file = Convert.FromBase64String(base64.Substring(base64.IndexOf(',') + 1));

                var mimeType = GetMimeTypeFromBase64(base64);

                using (var inputStream = new MemoryStream(file))
                {
                    using (var image = Image.Load(inputStream))
                    {
                        image.Mutate(x => x.Resize(new ResizeOptions
                        {
                            Size = new Size(width, height),
                            Mode = ResizeMode.Max
                        }));

                        using (var outputStream = new MemoryStream())
                        {
                            ImageEncoder imageEncoder = default!;

                            if (mimeType.EndsWith("png"))
                                imageEncoder = new PngEncoder();
                            else if (mimeType.EndsWith("jpeg"))
                                imageEncoder = new JpegEncoder { Quality = quality };
                            else if (mimeType.EndsWith("gif"))
                                imageEncoder = new GifEncoder();
                            else
                                throw new ResponseException(HttpStatusCode.UnsupportedMediaType, Enums.ExceptionResponseType.UnsupportedMediaType, new Exception($"Unsupported media type {mimeType} for UploadService"));

                            image.Save(outputStream, new JpegEncoder { Quality = quality });
                            return outputStream.ToArray();
                        }
                    }
                }
            }
    }
}


