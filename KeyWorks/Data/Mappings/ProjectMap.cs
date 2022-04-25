using KeyWorks.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KeyWorks.Api.Data.Mappings
{
    public class ProjectMap : IEntityTypeConfiguration<ProjectModel>
    {
        public void Configure(EntityTypeBuilder<ProjectModel> builder)
        {
            //Table name
            builder.ToTable("Project");

            //Primary Key
            builder.HasKey( x => x.Id);

            //Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            //Properties
            builder.Property(x => x.Name)
                .IsRequired()
                .HasColumnName("Name")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            //Fk
            builder.HasMany(x => x.Cards)
                .WithOne(x => x.Project)
                .HasConstraintName("FK_Project_Card")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
