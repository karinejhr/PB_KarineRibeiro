using Azure.Storage.Blobs;
using System;
using System.IO;
using System.Threading.Tasks;
using Domain.Services;

namespace Infrastructure.Storage
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;
        public BlobService(string connectionString)
        {
            _blobServiceClient = new BlobServiceClient(connectionString);
        }

        public async Task<string> UploadAsync(Stream stream)
        {
            var container = _blobServiceClient.GetBlobContainerClient("cbimages");

            await container.CreateIfNotExistsAsync();
            await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);

            var blobClient = container.GetBlobClient($"{Guid.NewGuid()}.jpg");

            await blobClient.UploadAsync(stream);
            return blobClient.Uri.ToString();

        }

        public async Task DeleteAsync(string blobName)
        {
            var container = _blobServiceClient.GetBlobContainerClient("cbimages");

            var blobClient = container.GetBlobClient(blobName);
            await blobClient.DeleteIfExistsAsync();
        }
    }
}