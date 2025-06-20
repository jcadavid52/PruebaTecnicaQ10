using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversidadQ10.Domain.Entities;

namespace UniversidadQ10.Infrastructure.DataSource
{
    public class RegistrationModelConfiguration : IEntityTypeConfiguration<Registration>
    {
        public void Configure(EntityTypeBuilder<Registration> builder)
        {
            builder.ToTable("InscripcionMaterias");

            builder.HasKey(registration => registration.Id);

            builder.Property(registration => registration.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(registration => registration.RegistrationDate)
                .HasColumnName("FechaInscripcion")
                .IsRequired();

            builder.HasOne(registration => registration.Student)
                .WithMany(student => student.Registration)
                .HasForeignKey(registration => registration.StudentId);

            builder.HasOne(registration => registration.Subject)
                .WithMany(student => student.Registration)
                .HasForeignKey(registration => registration.SubjectId);
        }
    }
}
