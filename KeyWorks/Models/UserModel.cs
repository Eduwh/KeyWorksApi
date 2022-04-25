using Microsoft.AspNetCore.Identity;

namespace KeyWorks.Api.Models
{
    //Making a UserModel class inherit of identityUser so we can have our own properties
    public class UserModel : IdentityUser
    {
        public IList<CardModel> Cards { get; set; }
    }
}
