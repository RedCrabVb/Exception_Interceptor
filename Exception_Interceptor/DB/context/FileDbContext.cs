using Exception_Interceptor.DB.model;
using Exception_Interceptor.Logic.DTO;
using Microsoft.EntityFrameworkCore;

namespace Exception_Interceptor.DB.context
{
    public class FileDbContext : DbContext
    {
        public FileDbContext(DbContextOptions<FileDbContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        }

        public DbSet<MyLineRecord> MyLineRecords { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSnakeCaseNamingConvention();
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableExample1Dto>()
                .HasNoKey();
        }
    }
}
