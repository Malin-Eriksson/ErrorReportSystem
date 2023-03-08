using ErrorReportSystem.MVVM.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ErrorReportSystem.Contexts;

internal class DataContext : DbContext
{
    private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\sangs\Documents\Webbutvecklare\Datalagring\Assignment\ErrorReportSystem\ErrorReportSystem\Contexts\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

    #region constructors
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    #endregion


    #region overrides
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }

    #endregion

    public DbSet<UnitEntity> Units { get; set; } = null!;

    public DbSet<ResidentEntity> Residents { get; set; } = null!;

    public DbSet<FaultReportEntity> FaultReports { get; set; } = null!;

    public DbSet<StatusEntity> Status { get; set; } = null!;

    public DbSet<CommentEntity> Comments { get; set; } = null!;


}
