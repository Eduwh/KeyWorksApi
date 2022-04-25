using Microsoft.AspNetCore.Mvc;
using KeyWorks.Api.Data;
using KeyWorks.Api.Models;
using KeyWorks.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace KeyWorks.Api.Controllers
{
    //Simple class with only a name column, here bellow are just the POST GET and PUT methods for said class
    [ApiController]
    [Route("ProjectController")]
    public class ProjectController : ControllerBase
    {
        [HttpPost]
        [Route("/register-project")]
        public IActionResult RegisterProject([FromBody] ProjectViewModel ProjectView, [FromServices] AppDbContext context)
        {
            var Project = new ProjectModel()
            {
                Name = ProjectView.Name
            };

            context.ProjectModels.Add(Project);
            context.SaveChanges();
            return Created($"/{Project.Id}", Project);
        }

        [HttpGet]
        [Route("/get-project{id:int}")]
        public IActionResult GetProjectById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var Project = context.ProjectModels.FirstOrDefault(x => x.Id == id);

            if (Project == null)
                return NotFound();

            return Ok(Project);
        }

        [HttpPut]
        [Route("/change-project-information")]
        public async Task<IActionResult> ChangeProjectInformation([FromRoute] int ProjectId, [FromBody] ProjectViewModel ProjectView, [FromServices] AppDbContext context)        
        {

            var Project = context.ProjectModels.Where(x => x.Id == ProjectId ).FirstOrDefault();

            if (Project == null)
                return NotFound();
            else
            {
                Project.Name = ProjectView.Name;
                context.SaveChanges();

                return Ok(Project);
            }
        }

        [HttpGet]
        [Route("/get-all-projects")]
        public IActionResult GetAllProjects([FromServices] AppDbContext context)
        {
            var status = context.GetAllProjects();

            if (status == null)
                return NotFound();

            return Ok(status);
        }
    }
}