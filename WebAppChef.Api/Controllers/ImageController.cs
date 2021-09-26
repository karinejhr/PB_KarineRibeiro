using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAppChef.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpPost]
        public async Task<IEnumerable<string>> Upload([FromServices] IChefBlobService chefblobService)
        {
            if (!Request.HasFormContentType)
                BadRequest();

            var tasks = Request.Form.Files.Select(file =>
            {
                return chefblobService.UploadAsync(file.OpenReadStream());
            });

            return await Task.WhenAll(tasks);
        }
    }
}
