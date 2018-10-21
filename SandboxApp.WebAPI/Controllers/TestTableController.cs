using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SandboxApp.Model.Service;
using SandboxApp.Model.Domain;

namespace SandboxApp.WebAPI.Controllers
{
    [Route("TestTables")]
    [ApiController]
    public class TestTableController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestTableController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public ActionResult<List<TestTable>> GetAll()
        {
            return _testService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<TestTable> Get([FromRoute] int id)
        {
            // This call will include the sub-items
            return _testService.Get(id);
        }
    }
}
