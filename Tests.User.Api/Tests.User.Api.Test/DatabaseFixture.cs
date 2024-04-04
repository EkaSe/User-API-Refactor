using Microsoft.EntityFrameworkCore;

namespace Tests.User.Api.Test
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseContext Context { get; }

        public DatabaseFixture()
        {
            Context = new DatabaseContext();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}