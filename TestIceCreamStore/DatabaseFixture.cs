using IceCreamStoreRepostery;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestIceCreamStore
{
    public class DatabaseFixture : IDisposable
    {
        public WebApiContext Context { get; private set; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<WebApiContext>()
                .UseSqlServer($"Server=LAPTOP-MOJ9OFNQ;Initial Catalog=Tests327742698;Integrated Security=True;TrustServerCertificate=True")
                .Options;

            Context = new WebApiContext(options);
            Context.Database.EnsureCreated();
        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
