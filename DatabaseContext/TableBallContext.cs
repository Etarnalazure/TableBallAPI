using Microsoft.EntityFrameworkCore;
using TableBallAPI.Models;

namespace TableBallAPI.DatabaseContext
{
    public class TableBallContext : DbContext
    {
        public TableBallContext(DbContextOptions<TableBallContext> options) : base(options)
        {
            
        }
        public DbSet<PlayerBaseModel> Players { get; set; }
        public DbSet<BattleBaseModel> Battles { get; set; }
        public DbSet<TeamBaseModel> Teams { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PlayerBaseModel>().ToTable("Player");
            modelBuilder.Entity<BattleBaseModel>().ToTable("Battle");
            modelBuilder.Entity<TeamBaseModel>().ToTable("Team");
        }
    }
}
