using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace sogeti_portfolio_api.Controllers
{
    [Route("profilepics")]
    [ApiController]
    public class FileUploadController : Controller
    {

        // add the connection string in the app.config
        private string _conn = "DefaultEndpointsProtocol=https;AccountName=profileappphotostorage;AccountKey=Rz4Bva3VkAipBe2pTE3rGKJyXJYUx9cG4AunSRBC5S9p1EFebeaMFAp3V1jIoCoNc3g+GTjuoDz7PCcFj089SA==;EndpointSuffix=core.windows.net";
        //look into creating interfaces for this setup and using dependency injection to use the functions.
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _container;
        private CloudStorageAccount _storageAccount;
        private CloudBlockBlob _blockBlob;
        public FileUploadController(CloudBlobClient blobClient, CloudBlobContainer container, CloudStorageAccount storageAccount, CloudBlockBlob blockBlob)
        {
            _blobClient =  blobClient;
            _container = container;
            _blockBlob = blockBlob;
            _storageAccount = storageAccount;
            _storageAccount = CloudStorageAccount.Parse(_conn);
            _blobClient = _storageAccount.CreateCloudBlobClient();
            _container = _blobClient.GetContainerReference("images");
        }

        [HttpGet("[Action]")]
        public async Task<IActionResult> Get(IFormFile files)
        {
            _blockBlob = _container.GetBlockBlobReference(files.FileName);

            //Create or overwrite the blob with contents of a local file
            using (var fileStream = files.OpenReadStream())
            {
                await _blockBlob.UploadFromStreamAsync(fileStream);

            }

            return Json(new
            {
                name = _blockBlob.Name,
                uri = _blockBlob.Uri,
                size = _blockBlob.Properties.Length
            });

        }

        [HttpPost("[Action]")]
        public async Task<IActionResult> SaveFile(IFormFile files)
        {
            //Get a reference to a blob
            _blockBlob = _container.GetBlockBlobReference(files.FileName);

            //Create or overwrite the blob with contents of a local file
            using (var fileStream = files.OpenReadStream())
            {
                await _blockBlob.UploadFromStreamAsync(fileStream);

            }
            return Json(new
            {
                name = _blockBlob.Name,
                uri = _blockBlob.Uri,
                size = _blockBlob.Properties.Length
            });
        }

        [HttpPost("[Action]")]
        async public Task<IActionResult> SaveAsString(IFormFile files, string photo)
        {
            photo = files.FileName;
            _blockBlob = _container.GetBlockBlobReference(files.FileName);
            //CloudBlockBlob blockBlob = container.GetBlockBlobReference(photo);

            //Create or overwrite the blob with contents of a local file
            using (var fileStream = files.OpenReadStream())
            {
                await _blockBlob.UploadFromStreamAsync(fileStream);

            }
            return Json(new
            {
                name = _blockBlob.Name,
                uri = _blockBlob.Uri,
                size = _blockBlob.Properties.Length
            });
        }
    }
}
