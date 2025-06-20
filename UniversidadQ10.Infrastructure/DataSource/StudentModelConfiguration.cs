using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversidadQ10.Domain.Common;
using UniversidadQ10.Domain.Entities;

namespace UniversidadQ10.Infrastructure.DataSource
{
    public class StudentModelConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Estudiante");

            builder.HasKey(student => student.Id);

            builder.Property(student => student.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(student => student.FullName)
                .HasColumnName("NombreCompleto")
                .HasMaxLength(StudentPropiertiesLength.FullNameMaxLength)
                .IsRequired();

            builder.Property(student => student.Document)
                .HasColumnName("Documento")
                .HasMaxLength(StudentPropiertiesLength.DocumentMaxLength)
                .IsRequired();

            builder.Property(student => student.Email)
                .HasColumnName("Correo")
                .HasMaxLength(StudentPropiertiesLength.EmailMaxLength)
                .IsRequired();

            builder.HasMany(student => student.Registration)
                   .WithOne(registration => registration.Student)
                   .HasForeignKey(registration => registration.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
