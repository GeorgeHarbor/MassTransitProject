using FormulaOne.DataService.Data;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService;

public class AchievementsRepository : GenericRepository<Achievement>, IAchievementsRepository
{
  public AchievementsRepository(AppDbContext context, ILogger logger) : base(context, logger)
  {
  }

  public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
  {
    try
    {
      return await _dbSet.FirstOrDefaultAsync(x => x.Driverid == driverId);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "{Repo} GetAchievementAchievement function error", typeof(AchievementsRepository));
      throw;
    }
  }

  public override async Task<IEnumerable<Achievement>> All()
  {
    try
    {
      return await _dbSet
        .AsNoTracking()
        .AsSplitQuery()
        .OrderBy(x => x.AddedDate)
        .ToListAsync();
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "{Repo} All function error", typeof(AchievementsRepository));
      throw;
    }
  }

  public override async Task<bool> Delete(Guid id)
  {
    try
    {
      var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

      if (result == null)
        return false;

      result.Status = 0;
      result.UpdatedDate = DateTime.UtcNow;

      return true;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "{Repo} Delete function error", typeof(AchievementsRepository));
      throw;
    }
  }

  public override async Task<bool> Update(Achievement achievement)
  {
    try
    {

      var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);

      if (result == null)
        return false;

      result.RaceWins = achievement.RaceWins;
      result.PolePosition = achievement.PolePosition;
      result.FastestLap = achievement.FastestLap;
      result.WorldChampionship = achievement.WorldChampionship;
      return true;
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "{Repo} Delete function error", typeof(AchievementsRepository));
      throw;
    }
  }

}
