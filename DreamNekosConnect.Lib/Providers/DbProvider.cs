using DreamNekosConnect.Lib.Models;
using Microsoft.EntityFrameworkCore;

namespace DreamNekosConnect.Lib.Providers
{
    public sealed class DbProvider
    {
        private static DbProvider _instance;
        private static ApplicationDbContext _context;
        private DbProvider() {
            DbConnectEnv DbConnectEnv = new DbConnectEnv { Host = "my_host", Database = "dreamneko_db", Username = "vanila", Password = "megapassVanill" };
            _context = new ApplicationDbContext(DbConnectEnv);
            _context.Database.EnsureCreated();
            _context.Database.Migrate();
        }

        public static DbProvider GetInstance()
        {
            if (_instance == null) {
                _instance = new DbProvider();
            }
            return _instance;
        }
        public ApplicationDbContext GetDbContext() => _context;
    }
}
