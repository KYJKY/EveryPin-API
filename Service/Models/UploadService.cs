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
using ExternalLibraryService;

namespace Service.Models
{
    public class UploadService : IUploadService
    {
        private readonly ILogger _logger;
        private readonly IRepositoryManager _repository;
        private readonly IConfiguration _configuration;
        private readonly BlobHandlingService _blobHandlingService;

        public UploadService(ILogger<UploadService> logger, IRepositoryManager repository, IConfiguration configuration, BlobHandlingService blobHandlingService)
        {
            _logger = logger;
            _repository = repository;
            _configuration = configuration;
            _blobHandlingService = blobHandlingService;
        }

        public string UploadTest(UploadImageInputDto UploadImageInputDto)
        {
            throw new NotImplementedException();
        }


    }
}
