using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;

namespace FormulaOne.DataService;

public interface IAchievementsRepository : IGenericRepository<Achievement>
{
  Task<Achievement?> GetDriverAchievementAsync(Guid driverId);

}
