using KeyWorks.Api.Data;
using KeyWorks.Api.Models;
using Newtonsoft.Json;
using System.Text;

namespace KeyWorks.Api.Context
{
    public class UserInitializer
    {
        private readonly AppDbContext _context;

        public UserInitializer(AppDbContext context)
            => _context = context;

        public void Initialize()
        {
            if (_context.Users.FirstOrDefault() == null)
            {
                var jsonData = File.ReadAllText("Data/JSON/user.json", Encoding.UTF8);
                SeedData(jsonData);
            }
        }

        public void SeedData(string jsonData)
        {
            var users = JsonConvert.DeserializeObject<List<UserModel>>(jsonData);

            foreach (var user in users )
            {
                _context.Add(user);
            }

            _context.SaveChanges();
        }
    }
}
