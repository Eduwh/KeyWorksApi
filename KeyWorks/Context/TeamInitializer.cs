using KeyWorks.Api.Data;
using KeyWorks.Api.Models;
using Newtonsoft.Json;
using System.Text;

namespace KeyWorks.Api.Context
{
    public class TeamInitializer
    {
        private readonly AppDbContext _context;

        public TeamInitializer(AppDbContext context)
            => _context = context;

        public void Initialize()
        {
            if (_context.TeamModels.FirstOrDefault() == null)
            {
                var jsonData = File.ReadAllText("Data/JSON/team.json", Encoding.UTF8);
                SeedData(jsonData);
            }
        }

        public void SeedData(string jsonData)
        {
            var teams = JsonConvert.DeserializeObject<List<TeamModel>>(jsonData);

            foreach (var team in teams )
            {
                _context.Add(team);
            }

            _context.SaveChanges();
        }
    }
}
