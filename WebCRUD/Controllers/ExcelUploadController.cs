using Microsoft.AspNetCore.Mvc;
using WebCRUDCore.cs.Interfaces;
using WebCRUDModel.cs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelUploadController : ControllerBase
    {
        private readonly IExcelCreator _excelCreator;

        public ExcelUploadController(IExcelCreator excelCreator)
        {
            _excelCreator = excelCreator;
        }


        //// GET: api/<ExcelUploadController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ExcelUploadController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ExcelUploadController>
        [HttpPost]
        public async Task<IActionResult> Post( IFormFile file)
        {



            await _excelCreator.uploadFile(file);
            return Ok("File uploaded and data inserted successfully.");
        }
        
        //[HttpPost]
        //public async Task<IActionResult> Post()
        //{
        //    // Access the request's body stream directly
        //    using (var stream = HttpContext.Request.Body)
        //    {
        //        await _excelCreator.UploadFileAsync(stream);
        //    }

        //    return Ok("File uploaded and data processed successfully.");
        //}


        //// PUT api/<ExcelUploadController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ExcelUploadController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
