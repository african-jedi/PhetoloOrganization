using System;
using Microsoft.EntityFrameworkCore;
using Phetolo.Math28.Core.Entities;

namespace Phetolo.Math28.Infrastructure.Configurations;

public class PuzzleStatisticsConfigurations: IEntityTypeConfiguration<PuzzleStatistics>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<PuzzleStatistics> builder)
    {
        builder.ToTable("PuzzleStatistics");

        builder.HasKey(p => new { p.Id });
        builder.HasOne(p => p.Puzzle).WithMany().IsRequired();
        builder.HasOne(p => p.User).WithMany().IsRequired();
        builder.Property(p => p.Completed).IsRequired();
        builder.Property(p => p.Attempts).IsRequired();
        builder.Property(p => p.CompletedTime).IsRequired();

        builder.Property<DateTime>("Created").IsRequired();
        builder.Property<DateTime>("Modified").IsRequired();
    }
}