
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiHumanos.Models;

namespace WebApiHumanos.Data.Configurations
{
    public class HumanoConfiguration : IEntityTypeConfiguration<Humano>
    {
        public void Configure(EntityTypeBuilder<Humano> builder)
        {
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Nombre)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(h => h.Sexo)
                .IsRequired()
                .HasMaxLength(5);

            builder.Property(h => h.Edad)
                .IsRequired();

            builder.Property(h => h.Altura)
                .IsRequired();

            builder.Property(h => h.Peso)
                .IsRequired();

            builder.HasData(
                new Humano { 
                    Id = 1, 
                    Nombre = "Marcos Palomino", 
                    Sexo = "M", 
                    Edad = 28, 
                    Altura = 1.65, 
                    Peso = 70 
                },
                new Humano { 
                    Id = 2, 
                    Nombre = "Cami Palomino", 
                    Sexo = "F", 
                    Edad = 1, 
                    Altura = 1, 
                    Peso = 10 
                }
            );
        }
    }
}
