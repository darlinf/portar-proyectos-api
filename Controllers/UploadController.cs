using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace UploadFileUsingDotNETCore.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        [HttpPost("upload", Name = "upload")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
       // public async Task<IActionResult> UploadFile(IFormFile file, CancellationToken cancellationToken)
        public async Task<IActionResult> UploadFile(
         IFormFile file,
         CancellationToken cancellationToken)
        {
            if (CheckIfExcelFile(file))
            {
                await WriteFile(file);
            }
            else
            {
                return BadRequest(new { message = "Invalid file extension" });
            }

            return Ok();
        }

        /// <summary>
        /// Method to check if file is excel file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool CheckIfExcelFile(IFormFile file)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];

            return (extension == ".png" || extension == ".jpg" || extension == ".pdf"); // Change the extension based on your need

            //return (extension == ".png" || extension == ".jpg"); // Change the extension based on your need

        }

        private async Task<bool> WriteFile(IFormFile file)
        {
            bool isSaveSuccess = false;
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = DateTime.Now.Ticks + extension; //Create a new Name for the file due to security reasons.


                string path = "";
                if (extension == ".png" || extension == ".jpg")
                {
                     path = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Images", fileName);
                }

                if (extension == ".pdf")
                {
                    path = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\pdf", fileName);
                }


                var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Images");

                if (!Directory.Exists(pathBuilt))
                {
                    Directory.CreateDirectory(pathBuilt);
                }

                path = Path.Combine(Directory.GetCurrentDirectory(), "Resources\\Images", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                isSaveSuccess = true;
            }
            catch (Exception e)
            {
                var ee = e;
                //log error
            }

            return isSaveSuccess;
        }
    }
}
