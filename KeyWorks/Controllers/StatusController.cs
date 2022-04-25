using Microsoft.AspNetCore.Mvc;
using KeyWorks.Api.Data;
using KeyWorks.Api.Models;
using KeyWorks.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace KeyWorks.Api.Controllers
{
    //Simple class with only a name column, here bellow are just the POST GET and PUT methods for said class
    [ApiController]
    [Route("StatusController")]
    public class StatusController : ControllerBase
    {
        [HttpPost]
        [Route("/register-status")]
        public IActionResult RegisterStatus([FromBody] StatusViewModel statusView, [FromServices] AppDbContext context)
        {
            var status = new StatusModel()
            {
                Name = statusView.Name
            };

            context.StatusModels.Add(status);
            context.SaveChanges();
            return Created($"/{status.Id}", status);
        }

        [HttpGet]
        [Route("/get-status{id:int}")]
        public IActionResult GetStatusById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var status = context.StatusModels.FirstOrDefault(card => card.Id == id);

            if (status == null)
                return NotFound();

            return Ok(status);
        }

        [HttpGet]
        [Route("/get-all-status")]
        public IActionResult GetAllStatus([FromServices] AppDbContext context)
        {
            var status = context.GetAllStatus();

            if (status == null)
                return NotFound();

            return Ok(status);
        }

        [HttpPut]
        [Route("/change-status-information")]
        public async Task<IActionResult> ChangeStatusInformation([FromRoute] int statusId, [FromBody] StatusViewModel statusView, [FromServices] AppDbContext context)        
        {

            var status = context.StatusModels.Where(x => x.Id == statusId ).FirstOrDefault();

            if (status == null)
                return NotFound();
            else
            {
                status.Name = statusView.Name;
                context.SaveChanges();

                return Ok(status);
            }
        }
    }
}