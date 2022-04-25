using System.ComponentModel.DataAnnotations;

namespace KeyWorks.ViewModels
{
    public class UserViewModel
    {
        //View model of the user class, to not have it all acessible to the user


        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
    }
}
