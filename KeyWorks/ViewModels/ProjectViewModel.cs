using System.ComponentModel.DataAnnotations;

namespace KeyWorks.ViewModels
{
    public class ProjectViewModel
    {
        //View model of the Project class, for good practices

        [Required]
        public string Name { get; set; }
    }
}
