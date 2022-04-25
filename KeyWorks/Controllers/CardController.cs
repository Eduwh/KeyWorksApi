using Microsoft.AspNetCore.Mvc;
using KeyWorks.Api.Data;
using KeyWorks.Api.Models;
using KeyWorks.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KeyWorks.Api.Controllers
{
    [ApiController]
    [Route("CardController")]
    public class CardController : ControllerBase
    {
        //User manager to get user information an adding it to cards or querys
        public UserManager<UserModel> userManager { get; }

        public CardController(UserManager<UserModel> userManager )
        {
            this.userManager = userManager;
        }


        //Simple registering card method
        [HttpPost]
        [Route("/register-card")]
        public async Task<IActionResult> RegisterCardAsync([FromBody] CardViewModel cardView, [FromServices] AppDbContext context)
        {
            var user = await userManager.GetUserAsync(User);
            var card = new CardModel()
            {
                StatusId = cardView.StatusId,
                Title = cardView.Title,
                Description = cardView.Description,
                CreatedDate = DateTime.Now,
                ForeseenDate = cardView.ForseenDateTime,
                UserId = user.Id,
                ProjectId = cardView.ProjectId,
                TeamId = cardView.TeamId,
                SectorId = cardView.SectorId,
                Priority = 0 // Making the priority 0 to make so any new card stays at the bottom of the lists
            };

            context.CardModels.Add(card);
            context.SaveChanges();
            return Created($"/{card.Id}", card);
        }        

        //Method to get all the logged user cards
        [HttpGet]
        [Route("/get-user-cards")]
        public async Task<IActionResult> GetUserCardsAsync([FromServices] AppDbContext context)
        {
            var user = await userManager.GetUserAsync(User);
            var cards = context.CardModels
                .Include(x => x.Status)
                .Include(x => x.Team)
                .Include(x => x.Sector)
                .Include(x => x.Project)
                .Where(x => user.Id == x.UserId)
                .Select( x => new
                    {
                       x.Id,
                       x.Title,
                       x.Description,
                       x.CreatedDate,
                       x.ForeseenDate,
                       x.Priority,                       
                       x.StatusId,
                       x.Status.Name,
                       x.ProjectId,
                       ProjectName = x.Project.Name,
                       x.TeamId,
                       TeamName = x.Team.Name,
                       x.SectorId,
                       SectorName = x.Sector.Name
                })
                .ToList();

            if (cards == null)
                return NotFound();

            return Ok(cards);
        }

        //Method to change the values of status ( given by the columns ) and priority ( given by the rows ) of any given card ( given by cardId )
        [HttpPatch]
        [Route("/change-card-position")]
        public async Task<IActionResult> ChangeCardPositionAsync([FromRoute] int statusId, [FromRoute] int priority, [FromRoute] int cardId, [FromServices] AppDbContext context)
        {
            var user = await userManager.GetUserAsync(User);
            var card = context.CardModels.Where(x => x.Id == cardId && x.UserId == user.Id).FirstOrDefault();

            if (card == null)
                return NotFound();
            else
            {
                card.StatusId = statusId;
                card.Priority = priority;
                context.SaveChanges();

                return Ok(card);
            }
        }

        //Changing card informations
        [HttpPatch]
        [Route("/change-card-information")]
        public async Task<IActionResult> ChangeCardInformationAsync([FromRoute] int cardId, [FromBody] CardViewModel cardView, [FromServices] AppDbContext context)
        {
            var user = await userManager.GetUserAsync(User);
            var card = context.CardModels.Where(x => x.Id == cardId && x.UserId == user.Id).FirstOrDefault();

            if (card == null)
                return NotFound();
            else
            {
                card.Title = cardView.Title;
                card.Description = cardView.Description;
                card.ForeseenDate = cardView.ForseenDateTime;
                card.ProjectId = cardView.ProjectId;
                card.TeamId = cardView.TeamId;
                card.SectorId = cardView.SectorId;
                context.SaveChanges();

                return Ok(card);
            }
        }
    }
}