using System.ComponentModel.DataAnnotations;

namespace KeyWorks.ViewModels
{
    public class TeamViewModel
    {
        //View model of the Team class, for good practices

        [Required]
        public string Name { get; set; }
    }
}
