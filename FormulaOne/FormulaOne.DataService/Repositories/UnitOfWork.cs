
using FormulaOne.DataService.Data;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService;

public class UnitOfWork : IUnitOfWork, IDisposable
{
  private readonly AppDbContext _context;
  private bool _disposed;

  public IDriverRepository Drivers { get; }
  public IAchievementsRepository Achievements { get; }

  public UnitOfWork(AppDbContext context, ILoggerFactory loggerFactory)
  {
    _context = context;
    var logger = loggerFactory.CreateLogger("logs");

    Drivers = new DriverRepository(_context, logger);
    Achievements = new AchievementsRepository(_context, logger);
  }

  public async Task<bool> CompleteAsync()
  {
    var result = await _context.SaveChangesAsync();
    return result > 0;
  }

  public void Dispose()
  {
    Dispose(true);
    GC.SuppressFinalize(this);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (_disposed) return;

    if (disposing)
      _context.Dispose();

    _disposed = true;
  }
}
