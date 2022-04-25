using KeyWorks.Api.Data;
using KeyWorks.Api.Models;
using Newtonsoft.Json;
using System.Text;

namespace KeyWorks.Api.Context
{
    public class ProjectInitializer
    {
        private readonly AppDbContext _context;

        public ProjectInitializer(AppDbContext context)
            => _context = context;

        public void Initialize()
        {
            if (_context.ProjectModels.FirstOrDefault() == null)
            {
                var jsonData = File.ReadAllText("Data/JSON/project.json", Encoding.UTF8);
                SeedData(jsonData);
            }
        }

        public void SeedData(string jsonData)
        {
            var projects = JsonConvert.DeserializeObject<List<ProjectModel>>(jsonData);

            foreach (var project in projects )
            {
                _context.Add(project);
            }

            _context.SaveChanges();
        }
    }
}
