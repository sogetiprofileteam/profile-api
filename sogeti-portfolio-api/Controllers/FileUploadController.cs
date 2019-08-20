using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

using sogeti_portfolio_api.Models;
using sogeti_portfolio_api.Interfaces;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;


namespace sogeti_portfolio_api.Controllers
{
   [Route ("profilepics")]
     //[Route ("coreskills")]
    [ApiController]

    
    public class FileUploadController: Controller {




        [HttpPost("[Action]")]
        async public Task<IActionResult> SaveFile(IFormFile files){
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=profileappphotostorage;AccountKey=Rz4Bva3VkAipBe2pTE3rGKJyXJYUx9cG4AunSRBC5S9p1EFebeaMFAp3V1jIoCoNc3g+GTjuoDz7PCcFj089SA==;EndpointSuffix=core.windows.net";
                //Set the configuration
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            //Create Blob Client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
          
            //Get a reference to container
            CloudBlobContainer container = blobClient.GetContainerReference("images");

            //Get a reference to a blob
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(files.FileName);
           // CloudBlockBlob blockBlob = container.GetBlockBlobReference("custom-name");


            //Create or overwrite the blob with contents of a local file
            using(var fileStream = files.OpenReadStream()){
                await blockBlob.UploadFromStreamAsync(fileStream);
             
            }
            return Json( new 
            {
                name = blockBlob.Name,
                uri = blockBlob.Uri,
                size = blockBlob.Properties.Length
            });

        }

                [HttpPost("[Action]")]
        async public Task<IActionResult> SaveAsString(IFormFile files, string photo){
            photo = files.FileName;
         
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=profileappphotostorage;AccountKey=Rz4Bva3VkAipBe2pTE3rGKJyXJYUx9cG4AunSRBC5S9p1EFebeaMFAp3V1jIoCoNc3g+GTjuoDz7PCcFj089SA==;EndpointSuffix=core.windows.net";
                //Set the configuration
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            //Create Blob Client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Get a reference to container
            CloudBlobContainer container = blobClient.GetContainerReference("images");

            //Get a reference to a blob
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(files.FileName);
            //CloudBlockBlob blockBlob = container.GetBlockBlobReference(photo);

            //Create or overwrite the blob with contents of a local file
            using(var fileStream = files.OpenReadStream()){
                await blockBlob.UploadFromStreamAsync(fileStream);

            }
            return Json( new 
            {
                name = blockBlob.Name,
                uri = blockBlob.Uri,
                size = blockBlob.Properties.Length
            });

        }

        [HttpGet("[Action]")]
    public async Task<IActionResult> Get(IFormFile files) 
      {
        
         string connectionString = "DefaultEndpointsProtocol=https;AccountName=profileappphotostorage;AccountKey=Rz4Bva3VkAipBe2pTE3rGKJyXJYUx9cG4AunSRBC5S9p1EFebeaMFAp3V1jIoCoNc3g+GTjuoDz7PCcFj089SA==;EndpointSuffix=core.windows.net";
                //Set the configuration
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            //Create Blob Client
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //Get a reference to container
            CloudBlobContainer container = blobClient.GetContainerReference("images");

            //Get a reference to a blob
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(files.FileName);

            //Create or overwrite the blob with contents of a local file
            using(var fileStream = files.OpenReadStream()){
                await blockBlob.UploadFromStreamAsync(fileStream);

            }

            return Json( new 
            {
                name = blockBlob.Name,
                uri = blockBlob.Uri,
                size = blockBlob.Properties.Length
            });

      }

    }
}
