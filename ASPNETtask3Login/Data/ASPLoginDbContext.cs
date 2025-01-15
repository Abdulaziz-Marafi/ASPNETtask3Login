using ASPNETtask3Login.Models;
using Microsoft.EntityFrameworkCore;

namespace ASPNETtask3Login.Data
{
    public class ASPLoginDbContext : DbContext
    {
        public ASPLoginDbContext(DbContextOptions<ASPLoginDbContext> options) : base(options){}

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
