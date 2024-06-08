using AutoMapper;
using Contracts.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Contracts.Models;
using Shared.DataTransferObject;
using Shared.DataTransferObject.InputDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;

namespace Service.Models
{
    public class UploadService : IUploadService
    {
        private readonly ILogger _logger;
        private readonly IRepositoryManager _repository;
        private readonly IConfiguration _configuration;

        public UploadService(ILogger<UploadService> logger, IRepositoryManager repository, IConfiguration configuration)
        {
            _logger = logger;
            _repository = repository;
            _configuration = configuration;
        }


        public string UploadTest(UploadImageInputDto UploadImageInputDto)
        {
            string result = "";
            string blobServiceEndpoint = _configuration.GetConnectionString("azure-storage-endpoint"); ; // Azure 포털에서 얻은 연결 문자열을 입력하세요
            string containerName = _configuration.GetConnectionString("azure-storage-container"); // Blob 컨테이너 이름

            // Azure Storage 연결
            BlobServiceClient serviceClient = GetBlobServiceClient(blobServiceEndpoint);
            BlobContainerClient containerClient = GetBlobContainerClient(serviceClient, containerName);

            //var test = UploadFromStreamAsync

            throw new NotImplementedException();

            return result;
        }

        private async Task UploadFromFileAsync(BlobContainerClient containerClient, string localFilePath)
        {
            string fileName = Path.GetFileName(localFilePath);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            await blobClient.UploadAsync(localFilePath, true);
        }

        public static async Task UploadFromBinaryDataAsync(BlobContainerClient containerClient, string localFilePath)
        {
            string fileName = Path.GetFileName(localFilePath);
            BlobClient blobClient = containerClient.GetBlobClient(fileName);

            FileStream fileStream = File.OpenRead(localFilePath);
            BinaryReader reader = new BinaryReader(fileStream);

            byte[] buffer = new byte[fileStream.Length];
            reader.Read(buffer, 0, buffer.Length);
            BinaryData binaryData = new BinaryData(buffer);

            await blobClient.UploadAsync(binaryData, true);

            fileStream.Close();
        }

        private BlobServiceClient GetBlobServiceClient(string blobServiceEndpoint)
        {
            BlobServiceClient client = new(
                new Uri(blobServiceEndpoint),
                new DefaultAzureCredential());

            return client;
        }

        private BlobContainerClient GetBlobContainerClient(BlobServiceClient blobServiceClient, string containerName)
        {
            // Create the container client using the service client object
            BlobContainerClient client = blobServiceClient.GetBlobContainerClient(containerName);
            return client;
        }
    }
}
