using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HelloWorld.Controllers
{
    [Route("/")]
    [ApiController]
    public class MainPageController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {   
            var path = "./Html/main-page.html";

            StreamReader reader = new StreamReader(path);

            var fileBytes = System.IO.File.ReadAllBytes(path);

            FileContentResult file = File(fileBytes, "text/html");

            return file;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}
