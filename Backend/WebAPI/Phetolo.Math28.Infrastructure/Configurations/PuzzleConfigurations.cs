using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Phetolo.Math28.Core.Entities;
using Phetolo.Math28.Infrastructure.Constants;

namespace Phetolo.Math28.Infrastructure.Configurations;

public class PuzzleConfigurations: IEntityTypeConfiguration<Puzzle>
{
    public void Configure(EntityTypeBuilder<Puzzle> builder)
    {
        builder.ToTable(TableNames.Puzzles);
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Scramble).IsRequired().HasColumnType("varchar(100)");
        builder.Property(p => p.Answer).IsRequired().HasColumnType("varchar(100)");
        builder.Property<DateTime>("Created").IsRequired();
        builder.Property<DateTime>("Modified").IsRequired();
    }
}
