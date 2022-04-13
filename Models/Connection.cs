using Microsoft.EntityFrameworkCore;
using Trello_Duda.Models;

namespace Trello_Duda.Models
{
    public class Connection : DbContext
    {
        public Connection(DbContextOptions<Connection> options)
            :base(options)
        {    
        }

        public DbSet<Cards> Cards { get; set; }

        public DbSet<Trello_Duda.Models.SprintsInfo> SprintsInfo { get; set; }

        public DbSet<Trello_Duda.Models.UsersInfo> UsersInfo { get; set; }
    }
}
