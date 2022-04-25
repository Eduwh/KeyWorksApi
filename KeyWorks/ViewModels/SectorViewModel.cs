using System.ComponentModel.DataAnnotations;

namespace KeyWorks.ViewModels
{
    public class SectorViewModel
    {
        //View model of the Sector class, for good practices

        [Required]
        public string Name { get; set; }
    }
}
