using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObject.Blob;

namespace ExternalLibraryService
{
    public class BlobHandlingService
    {
        private readonly BlobServiceClient _blobService;
        private readonly BlobContainerClient _blobContainer;

        #region 세팅
        public BlobHandlingService(string accessKey, string storageAccountName, string containerName)
        {

            _blobService = GetBlobServiceClient(storageAccountName, accessKey);
            _blobContainer = GetBlobContainerClient(containerName);
        }

        private BlobServiceClient GetBlobServiceClient(string storageAccountName, string accessKey)
        {
            var credential = new StorageSharedKeyCredential(storageAccountName, accessKey);
            string blobUri = $"https://{storageAccountName}.blob.core.windows.net";

            BlobServiceClient client = new BlobServiceClient(new Uri(blobUri), credential);

            return client;
        }

        public BlobContainerClient GetBlobContainerClient(string containerName)
        {
            return _blobService.GetBlobContainerClient(containerName);
        }

        //public BlobClient GetBlobClient(string blobName)
        //{
        //    return _blobContainer.GetBlobClient(blobName);
        //}
        #endregion

        /// <summary>
        /// Blob Storage 컨테이너 내 모든 Blob List 반환
        /// </summary>
        /// <returns></returns>
        public async Task<List<BlobDto>> ListAsync()
        {
            List<BlobDto> files = new List<BlobDto>();

            await foreach (var file in _blobContainer.GetBlobsAsync())
            {
                string uri = _blobContainer.Uri.ToString();
                var name = file.Name;
                var fullUri = $"{uri}/{name}";

                files.Add(new BlobDto
                {
                    Uri = uri,
                    Name = name,
                    ContentType = file.Properties.ContentType,
                });
            }

            return files;
        }

        /// <summary>
        /// Blob Storage 컨테이너에 파일 업로드
        /// </summary>
        /// <param name="blob"></param>
        /// <returns></returns>
        public async Task<BlobResponseDto> UploadAsync(IFormFile blob)
        {
            BlobResponseDto response = new BlobResponseDto();
            BlobClient client = _blobContainer.GetBlobClient(blob.FileName);

            await using (Stream? data = blob.OpenReadStream())
            {
                await client.UploadAsync(data);
            }

            response.Status = $"{blob.FileName} 업로드 완료";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = client.Name;

            return response;
        }

        /// <summary>
        /// Blob Storage 컨테이너에 특정 파일 반환하기
        /// </summary>
        /// <param name="blobFileName"></param>
        /// <returns></returns>
        public async Task<BlobDto?> DownloadAsync(string blobFileName)
        {
            BlobClient file = _blobContainer.GetBlobClient(blobFileName);

            if (await file.ExistsAsync())
            {
                var data = await file.OpenReadAsync();
                var content = await file.DownloadContentAsync();

                string name = blobFileName;
                string contentType = content.Value.Details.ContentType;

                return new BlobDto { Content = data, Name = name, ContentType = contentType };
            }

            return null;
        }

        /// <summary>
        /// Blob Storage 컨테이너 내 특정 파일 삭제하기
        /// </summary>
        /// <param name="blobFileName"></param>
        /// <returns></returns>
        public async Task<BlobResponseDto> DeleteAsync(string blobFileName)
        {
            BlobClient file = _blobContainer.GetBlobClient(blobFileName);
            await file.DeleteAsync();

            return new BlobResponseDto { Error = false, Status = $"{blobFileName} 삭제 완료" };
        }
    }
}
