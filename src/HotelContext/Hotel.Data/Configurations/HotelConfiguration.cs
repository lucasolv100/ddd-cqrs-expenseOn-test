using Hotel.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Data.Configurations
{
    public class HotelConfiguration : IEntityTypeConfiguration<Domain.Entites.Hotel>
    {
        public void Configure(EntityTypeBuilder<Domain.Entites.Hotel> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).UseSqlServerIdentityColumn();

            builder.Ignore(i => i.Notifications);
            builder.Ignore(i => i.Invalid);
            builder.Ignore(i => i.Valid);

            builder.Property(p => p.Name).HasMaxLength(50).IsRequired().HasColumnName("Nome");
            builder.Property(p => p.Description).HasMaxLength(255).IsRequired().HasColumnName("Descricao");
            builder.Property(p => p.Rating).HasColumnType("decimal(10,2)").IsRequired().HasColumnName("Avaliacao");
            builder.Property(p => p.Features).HasMaxLength(500).IsRequired().HasColumnName("Comodidades");
            
            builder.OwnsOne(p => p.Address, a =>
            {
                a.Property(c => c.Street).HasMaxLength(50).IsRequired().HasColumnName("Rua");
                a.Property(c => c.ZipCode).HasMaxLength(20).IsRequired().HasColumnName("CEP");
                a.Property(c => c.Number).HasMaxLength(9).IsRequired().HasColumnName("Numero");
                a.Property(c => c.City).HasMaxLength(100).IsRequired().HasColumnName("Cidade");
                a.Property(c => c.State).HasMaxLength(50).IsRequired().HasColumnName("Estado");
            });
            

            builder.Property(p => p.CreateDate).HasColumnName("DataCriacao");
            builder.Property(p => p.EditDate).HasColumnName("DataEdicao");
            builder.Property(p => p.DeleteDate).HasColumnName("DataExclusao");

        }
    }
}