using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF_Core.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(n => n.CategoryId);
            builder.Property(n=> n.CategoryName).IsRequired();

            builder.HasData(
               new Category()
               {
                   CategoryId=1,
                   CategoryName="Developer"
               },
               new Category()
               {
                   CategoryId = 2,
                   CategoryName = "Network"
               },
               new Category()
               {
                   CategoryId = 3,
                   CategoryName = "Coding"
               }
            );
        }
    }
}
