using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TaxManagement.DataLayer.Model;

namespace TaxManagement.DataLayer.Configurations
{
    internal class TaxDeclarationConfig : IEntityTypeConfiguration<TaxDeclaration>
    {
        public void Configure(EntityTypeBuilder<TaxDeclaration> builder)
        {
            builder.Property(x => x.PublishedOn)
                   .HasColumnType("date");

            var utcConverter = new ValueConverter<DateTime, DateTime>(
                toDb => toDb,
                fromDb => DateTime.SpecifyKind(fromDb, DateTimeKind.Utc));

            builder.Property(e => e.PublishedOn)
                   .HasConversion(utcConverter);

            builder.Property(x => x.AmountOfActOfReconciliation)
                  .HasPrecision(18, 5); 

            builder.Property(x => x.AmountOfCurrentReportingPeriod)
                   .HasPrecision(18, 5);

            builder.Property(x => x.AmountOfPreviousReportingPeriod)
                   .HasPrecision(18, 5);

            builder.Property(x => x.AmountOfTaxToBePaid)
                  .HasPrecision(18, 5);

            builder.Property(x => x.ReportingPeriod)  
                   .HasConversion<string>();    //this will save ReportingPeriod enum in DB as string instead of int

        }
    }
}
