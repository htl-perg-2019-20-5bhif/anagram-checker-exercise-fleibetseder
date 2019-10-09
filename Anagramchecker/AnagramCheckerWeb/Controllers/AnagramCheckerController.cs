using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anagramchecker;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnagramCheckerWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnagramCheckerController : ControllerBase
    {
        private readonly ILogger<AnagramCheckerController> _logger;

        public AnagramCheckerController(ILogger<AnagramCheckerController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet]
        [Route("/api/checkAnagram")]
        public ActionResult<string> GetCheckAnagrams([FromBody]WordPair data)
        {
            if (data is null)
            {
                return BadRequest();
            }
            Anagramchecker anagramChecker = new Anagramchecker();
            if (anagramChecker.CheckWords(data.w1, data.w2))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
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
