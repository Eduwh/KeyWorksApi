using Microsoft.EntityFrameworkCore;
using KeyWorks.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using KeyWorks.Api.Data.Mappings;

namespace KeyWorks.Api.Data
{
    public class AppDbContext : IdentityDbContext<UserModel>
    {
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<CardModel> CardModels { get; set; }
        public DbSet<StatusModel> StatusModels { get; set; }
        public DbSet<ProjectModel> ProjectModels { get; set; }
        public DbSet<TeamModel> TeamModels { get; set; }
        public DbSet<SectorModel> SectorModels { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public AppDbContext() : base() { }

        protected override void OnModelCreating( ModelBuilder builder )
        {
            //This makes so there is no need of a UserMap
            base.OnModelCreating(builder);
            //Changing the table name from AspNetUsers to User
            builder.Entity<UserModel>(x => x.ToTable("User"));           

            //Fk
            builder.Entity<UserModel>(x => x.HasMany(x => x.Cards)
                .WithOne(x => x.User)
                .HasConstraintName("FK_User_Card")
                .OnDelete(DeleteBehavior.Cascade));

            builder.ApplyConfiguration(new CardMap());
            builder.ApplyConfiguration(new StatusMap());
            builder.ApplyConfiguration(new ProjectMap());
            builder.ApplyConfiguration(new TeamMap());
            builder.ApplyConfiguration(new SectorMap());
        }

        //Replace here with your sqlServer string connection
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=DESKTOP-MU5JC2T\\MSSQLSERVER02;Database=KeyWorks;User ID=eduardo.lucrezia;Password=123");

        public virtual List<StatusModel> GetAllStatus()
        {
            return StatusModels.ToList();
        }

        public virtual List<TeamModel> GetAllTeams()
        {
            return TeamModels.ToList();
        }

        public virtual List<ProjectModel> GetAllProjects()
        {
            return ProjectModels.ToList();
        }

        public virtual List<SectorModel> GetAllSectors()
        {
            return SectorModels.ToList();
        }

    }
}