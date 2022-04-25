using KeyWorks.Api.Data;
using KeyWorks.Api.Models;
using Newtonsoft.Json;
using System.Text;

namespace KeyWorks.Api.Context
{
    public class SectorInitializer
    {
        private readonly AppDbContext _context;

        public SectorInitializer(AppDbContext context)
            => _context = context;

        public void Initialize()
        {
            if (_context.SectorModels.FirstOrDefault() == null)
            {
                var jsonData = File.ReadAllText("Data/JSON/sector.json", Encoding.UTF8);
                SeedData(jsonData);
            }
        }

        public void SeedData(string jsonData)
        {
            var sectors = JsonConvert.DeserializeObject<List<SectorModel>>(jsonData);

            foreach (var sector in sectors )
            {
                _context.Add(sector);
            }

            _context.SaveChanges();
        }
    }
}
