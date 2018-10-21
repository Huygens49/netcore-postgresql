using Microsoft.AspNetCore.Mvc;
using SandboxApp.Model.Domain;
using SandboxApp.Model.Exceptions;
using SandboxApp.Model.Service;
using System;
using System.Collections.Generic;

namespace SandboxApp.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestTablesController : ControllerBase
    {
        private readonly ITestService _testService;

        public TestTablesController(ITestService testService)
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
            try
            {
                // This call will include the sub-items
                return _testService.Get(id);
            }
            catch (Exception ex)
            {
                if (ex is ItemNotFoundException) return NotFound();

                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult Add([FromBody] TestTable testTable)
        {
            try
            {
                _testService.Add(testTable);
                return CreatedAtAction("Get", new { id = testTable.Testid }, testTable);
            }
            catch (Exception ex)
            {
                if (ex is ItemNotFoundException) return NotFound();
                else if (ex is InvalidInputException) return BadRequest();

                return StatusCode(500);
            }
        }

        [HttpPut]
        public ActionResult Update([FromBody] TestTable testTable)
        {
            try
            {
                _testService.Update(testTable);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex is ItemNotFoundException) return NotFound();
                else if (ex is InvalidInputException) return BadRequest();

                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                _testService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex is ItemNotFoundException) return NotFound();

                return StatusCode(500);
            }
        }
    }
}
