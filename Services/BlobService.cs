using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace API_proj.Services
{
    public class BlobService
    {
        private readonly string _connectionString = "UseDevelopmentStorage=true";
        private readonly string _containerName = "raceday-images";

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0) return string.Empty;
            var containerClient = new BlobContainerClient(_connectionString, _containerName);
            var blobClient = containerClient.GetBlobClient($"{Guid.NewGuid()}_{file.FileName}");
            using var stream = file.OpenReadStream();
            await blobClient.UploadAsync(stream, true);
            return blobClient.Uri.ToString();
        }
    }
}