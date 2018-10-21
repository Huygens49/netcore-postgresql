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
    public class TestSubTablesController : ControllerBase
    {
        private readonly ITestSubService _testSubService;

        public TestSubTablesController(ITestSubService testSubService)
        {
            _testSubService = testSubService;
        }

        [HttpGet("{id}")]
        public ActionResult<TestSubTable> GetSubTable([FromRoute] int id)
        {
            try
            {
                // This call will include the sub-items
                return _testSubService.Get(id);
            }
            catch (Exception ex)
            {
                if (ex is ItemNotFoundException) return NotFound();

                return StatusCode(500);
            }
        }

        [HttpPost]
        public ActionResult AddSubTable([FromBody] TestSubTable testSubTable)
        {
            try
            {
                _testSubService.Add(testSubTable);
                return CreatedAtAction("GetSubTable", new { id = testSubTable.Testid }, testSubTable);
            }
            catch (Exception ex)
            {
                if (ex is ItemNotFoundException) return NotFound();
                else if (ex is InvalidInputException) return BadRequest();

                return StatusCode(500);
            }
        }

        [HttpPut]
        public ActionResult Update([FromBody] TestSubTable testSubTable)
        {
            try
            {
                _testSubService.Update(testSubTable);
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
        public ActionResult DeleteSubTable([FromRoute] int id)
        {
            try
            {
                _testSubService.Delete(id);
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
