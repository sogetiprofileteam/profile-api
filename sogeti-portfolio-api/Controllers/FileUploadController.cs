using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.File;


namespace sogeti_portfolio_api.Controllers
{
    [Route("profilepics")]
    [ApiController]
    public class FileUploadController : Controller
    {

        // add the connection string in the app.config
        private string _conn = Environment.GetEnvironmentVariable("CONNECT_STR");
        //look into creating interfaces for this setup and using dependency injection to use the functions.
        private CloudBlobClient _blobClient;
        private CloudBlobContainer _container;
        private CloudStorageAccount _storageAccount;
        private CloudBlockBlob _blockBlob;
        // public FileUploadController(CloudBlobClient blobClient, CloudBlobContainer container, CloudStorageAccount storageAccount, CloudBlockBlob blockBlob)
        // {
        //     _blobClient =  blobClient;
        //     _container = container;
        //     _blockBlob = blockBlob;
        //     _storageAccount = storageAccount;
        //     _storageAccount = CloudStorageAccount.Parse(_conn);
        //     _blobClient = _storageAccount.CreateCloudBlobClient();
        //     _container = _blobClient.GetContainerReference("images");
        // }

        [HttpGet("[Action]")]
        public async Task<IActionResult> GetProfilePic(string fileName)
        {

            try
            {
                var request = await HttpContext.Request.ReadFormAsync();
                if (request.Files == null)
                {
                    return BadRequest("Could not get file");
                }
                var files = request.Files;

                for (int i = 0; i < files.Count; i++)
                {
                    if (fileName == files[i].FileName)
                    {
                        _blockBlob = _container.GetBlockBlobReference(files[i].FileName);
                        using (var fileStream = files[i].OpenReadStream())
                        {
                            await _blockBlob.DownloadToStreamAsync(fileStream);

                        }
                    }
                }
                return Ok(_blockBlob.Uri);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                // return Json(new {
                //     error = "Couldn't find file"
                // });
            }

            //    _blockBlob = _container.GetBlockBlobReference(fileName);
            //     _blockBlob.Properties.ContentType = "image/jpg";
            //     await _blockBlob.SetPropertiesAsync();
            //     return Ok(_blockBlob);
        }

        //Receives file from front end and sends to azure blob
        [HttpPost("[Action]")]
        public async Task<IActionResult> UploadFileAsync(IFormFile file)
        {
            _storageAccount = null;
            if (CloudStorageAccount.TryParse(_conn, out _storageAccount))
            {
                _storageAccount = CloudStorageAccount.Parse(_conn);
                _blobClient = _storageAccount.CreateCloudBlobClient();
                _container = _blobClient.GetContainerReference("images");
                await _container.CreateIfNotExistsAsync();

                //Get a reference to a blob
                _blockBlob = _container.GetBlockBlobReference(file.FileName);
                _blockBlob.Properties.ContentType = "image/jpg";

                //  await _blobClient.GetBlobReferenceFromServerAsync(blob.Uri);

                //Create or overwrite the blob with contents of a local file
                await _blockBlob.UploadFromStreamAsync(file.OpenReadStream());
                return Ok(_blockBlob.Uri);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }



        [HttpPost("[Action]")]
        async public Task<IActionResult> SaveAsString(IFormFile files, string photo)
        {
            photo = files.FileName;
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


    }
}
