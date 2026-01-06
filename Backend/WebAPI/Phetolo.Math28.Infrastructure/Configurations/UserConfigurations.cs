using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phetolo.Math28.Infrastructure.Constants;

namespace Phetolo.Math28.Infrastructure.Configurations;

public class UserConfigurations: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(TableNames.Users);
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(100)");
        builder.Property(p => p.Surname).IsRequired().HasColumnType("varchar(100)");
        builder.Property(p => p.Email).IsRequired().HasColumnType("varchar(254)");
        builder.Property(p => p.IPAdress).IsRequired().HasColumnType("varchar(100)");

        builder.Property<DateTime>("Created").IsRequired();
        builder.Property<DateTime>("Modified").IsRequired();
    }
}
