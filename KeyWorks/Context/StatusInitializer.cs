using KeyWorks.Api.Data;
using KeyWorks.Api.Models;
using Newtonsoft.Json;
using System.Text;

namespace KeyWorks.Api.Context
{
    public class StatusInitializer
    {
        private readonly AppDbContext _context;

        public StatusInitializer(AppDbContext context)
            => _context = context;

        public void Initialize()
        {
            if (_context.StatusModels.FirstOrDefault() == null)
            {
                var jsonData = File.ReadAllText("Data/JSON/status.json", Encoding.UTF8);
                SeedData(jsonData);
            }
        }

        public void SeedData(string jsonData)
        {
            var statusModels = JsonConvert.DeserializeObject<List<StatusModel>>(jsonData);

            foreach (var status in statusModels )
            {
                _context.Add(status);
            }

            _context.SaveChanges();
        }
    }
}
