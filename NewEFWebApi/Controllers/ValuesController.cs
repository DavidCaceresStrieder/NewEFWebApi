using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Models.Promises;
//using ModelsLayer.Models.Promises;

namespace DCSCoreFramework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IUserDB _userDB;
        public ValuesController(IUserDB userDB)
        {
            this._userDB = userDB;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<int> Get()
        {
            return _userDB.Query().Count();            
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<object> Get(int id)
        {                        
            
            var rv = _userDB.Load(id);
            return rv;
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
