using Microsoft.AspNetCore.Mvc;
using KeyWorks.Api.Data;
using KeyWorks.Api.Models;
using KeyWorks.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace KeyWorks.Api.Controllers
{
    //Simple class with only a name column, here bellow are just the POST GET and PUT methods for said class
    [ApiController]
    [Route("TeamController")]
    public class TeamController : ControllerBase
    {
        [HttpPost]
        [Route("/register-team")]
        public IActionResult RegisterTeam([FromBody] TeamViewModel TeamView, [FromServices] AppDbContext context)
        {
            var Team = new TeamModel()
            {
                Name = TeamView.Name
            };

            context.TeamModels.Add(Team);
            context.SaveChanges();
            return Created($"/{Team.Id}", Team);
        }

        [HttpGet]
        [Route("/get-team{id:int}")]
        public IActionResult GetTeamById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var Team = context.TeamModels.FirstOrDefault(x => x.Id == id);

            if (Team == null)
                return NotFound();

            return Ok(Team);
        }

        [HttpPut]
        [Route("/change-team-information")]
        public async Task<IActionResult> ChangeTeamInformation([FromRoute] int TeamId, [FromBody] TeamViewModel TeamView, [FromServices] AppDbContext context)        
        {

            var Team = context.TeamModels.Where(x => x.Id == TeamId ).FirstOrDefault();

            if (Team == null)
                return NotFound();
            else
            {
                Team.Name = TeamView.Name;
                context.SaveChanges();

                return Ok(Team);
            }
        }

        [HttpGet]
        [Route("/get-all-teams")]
        public IActionResult GetAllTeams([FromServices] AppDbContext context)
        {
            var status = context.GetAllTeams();

            if (status == null)
                return NotFound();

            return Ok(status);
        }
    }
}