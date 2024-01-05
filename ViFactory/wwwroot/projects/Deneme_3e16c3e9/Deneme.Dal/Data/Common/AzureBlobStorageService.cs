using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace Deneme.Dal.Data.Common
{
    public class AzureBlobStorageService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public AzureBlobStorageService(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }
        public async Task<Response<BlobContentInfo>> Upload(string containerName, string folder, string fileName, byte[] bytes)
        {
            var containerClient = await GetContainerClient(containerName);

            var blobClient = containerClient.GetBlobClient(Path.Combine(folder, fileName));

            return await blobClient.UploadAsync(BinaryData.FromBytes(bytes));
        }
        public async Task<(Response<BlobDownloadResult> Response, byte[]? Content)> Download(string containerName, string folder, string fileName)
        {
            var containerClient = await GetContainerClient(containerName);

            var blobClient = containerClient.GetBlobClient(Path.Combine(folder, fileName));

            Response<BlobDownloadResult> response = await blobClient.DownloadContentAsync();

            if (response.Value != null && response.Value.Content != null)
            {
                return (response, response.Value.Content.ToArray());
            }

            return (response, null);
        }
        public async Task<Response<bool>> Delete(string containerName, string folder, string fileName)
        {
            var containerClient = await GetContainerClient(containerName);

            var blobClient = containerClient.GetBlobClient(Path.Combine(folder, fileName));

            return await blobClient.DeleteIfExistsAsync();
        }
        public async Task<List<BlobItem>> ListBlobItems(string containerName)
        {
            var containerClient = await GetContainerClient(containerName);

            List<BlobItem> blobItems = new List<BlobItem>();

            await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
            {
                blobItems.Add(blobItem);
            }

            return blobItems;
        }
        private async Task<BlobContainerClient> GetContainerClient(string containerName)
        {
            BlobContainerClient client = _blobServiceClient.GetBlobContainerClient(containerName);

            await client.CreateIfNotExistsAsync();

            return client;
        }
    }
}
