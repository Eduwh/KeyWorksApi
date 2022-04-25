using System.ComponentModel.DataAnnotations;

namespace KeyWorks.ViewModels
{
    public class CardViewModel
    {
        //View model of the card class, for good practices

        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int StatusId { get; set; }        
        [Required]
        public DateTime ForseenDateTime { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int SectorId { get; set; }
    }
}
