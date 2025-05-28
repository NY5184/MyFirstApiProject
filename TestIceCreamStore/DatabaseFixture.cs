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
        private readonly string _databaseName;

        public DatabaseFixture()
        {
            _databaseName = "TestDb_" + Guid.NewGuid().ToString("N");
            var options = new DbContextOptionsBuilder<WebApiContext>()
                .UseSqlServer($"Data Source=LAPTOP-MOJ9OFNQ;Initial Catalog={_databaseName};Integrated Security=True;TrustServerCertificate=True")
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
