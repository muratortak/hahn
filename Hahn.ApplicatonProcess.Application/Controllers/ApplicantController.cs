using Hahn.ApplicatonProcess.May2020.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hahn.ApplicatonProcess.May2020.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicant _applicantService;

        // DI
        public ApplicantController(IApplicant applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet("{id}"), ActionName("Get")]
        public IActionResult Get([FromRoute] int id)
        {
            var applicant = _applicantService.GetApplicant(id);
            if(applicant == null) 
            {
                return NotFound();
            }
            return Ok(applicant);
            
        }

        // POST api/<ApplicantController>
        [HttpPost]
        public IActionResult Post([FromBody] BusinessApplicant applicant)
        {

            BusinessApplicant newApplicant = applicant;
            
            try
            {
                // Cerate the new applicant and get its id.
                int newID = _applicantService.CreateApplicant(newApplicant);
                // Send the url back to the client with the newly created applicant's id.
                return CreatedAtAction(nameof(ApplicantController.Get), new { id = newID}, null);
            }
            catch(Exception ex)
            {
                return BadRequest($"bad request: {ex.Message}");
            }
        }

        // PUT api/<ApplicantController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BusinessApplicant value)
        {
            try
            {
                _applicantService.UpdateApplicant(id, value);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest($"Bad Request {ex.Message}");
            }
        }

        // DELETE api/<ApplicantController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _applicantService.DeleteApplicant(id);
                return Ok();
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }
    }
}
