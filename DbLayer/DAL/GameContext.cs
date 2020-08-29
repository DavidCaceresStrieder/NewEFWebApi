using Microsoft.EntityFrameworkCore;

namespace ModelsLayer.DAL
{
    public class UnitOfWork : DbContext
    {

        public UnitOfWork(DbContextOptions<UnitOfWork> options) : base(options) { }


        public DbSet<User> Users { get; set; }        

    }
}
