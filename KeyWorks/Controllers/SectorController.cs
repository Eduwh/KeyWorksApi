using Microsoft.AspNetCore.Mvc;
using KeyWorks.Api.Data;
using KeyWorks.Api.Models;
using KeyWorks.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace KeyWorks.Api.Controllers
{
    //Simple class with only a name column, here bellow are just the POST GET and PUT methods for said class
    [ApiController]
    [Route("SectorController")]
    public class SectorController : ControllerBase
    {
        [HttpPost]
        [Route("/register-sector")]
        public IActionResult RegisterSector([FromBody] SectorViewModel SectorView, [FromServices] AppDbContext context)
        {
            var Sector = new SectorModel()
            {
                Name = SectorView.Name
            };

            context.SectorModels.Add(Sector);
            context.SaveChanges();
            return Created($"/{Sector.Id}", Sector);
        }

        [HttpGet]
        [Route("/get-sector{id:int}")]
        public IActionResult GetSectorById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var Sector = context.SectorModels.FirstOrDefault(x => x.Id == id);

            if (Sector == null)
                return NotFound();

            return Ok(Sector);
        }

        [HttpPut]
        [Route("/change-sector-information")]
        public async Task<IActionResult> ChangeSectorInformation([FromRoute] int SectorId, [FromBody] SectorViewModel SectorView, [FromServices] AppDbContext context)        
        {

            var Sector = context.SectorModels.Where(x => x.Id == SectorId ).FirstOrDefault();

            if (Sector == null)
                return NotFound();
            else
            {
                Sector.Name = SectorView.Name;
                context.SaveChanges();

                return Ok(Sector);
            }
        }

        [HttpGet]
        [Route("/get-all-sectors")]
        public IActionResult GetAllSectors([FromServices] AppDbContext context)
        {
            var status = context.GetAllSectors();

            if (status == null)
                return NotFound();

            return Ok(status);
        }
    }
}