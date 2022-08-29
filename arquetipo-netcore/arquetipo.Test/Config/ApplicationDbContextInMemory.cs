using arquetipo.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arquetipo.Test.Config
{
    public static class ApplicationDbContextInMemory
    {
        public static BlogContext Get()
        {
            var options = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(databaseName: $"CreditoVehicular.Db")
                .Options;
            return new BlogContext(options);
        }
    }
}
