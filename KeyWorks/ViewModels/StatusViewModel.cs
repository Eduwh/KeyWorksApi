using System.ComponentModel.DataAnnotations;

namespace KeyWorks.ViewModels
{
    public class StatusViewModel
    {
        //View model of the Status class, for good practices

        [Required]
        public string Name { get; set; }
    }
}
