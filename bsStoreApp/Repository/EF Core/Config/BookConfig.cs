using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EF_Core.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, Title = "Simyacı", Price = 125 },
                new Book { Id = 2, Title = "Dede Korkut", Price = 175 },
                new Book { Id = 3, Title = "Mesnevi", Price = 215 }
              );

        }
    }
}
