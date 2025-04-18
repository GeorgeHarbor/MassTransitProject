namespace FormulaOne.DataService;

public interface IUnitOfWork
{
  IDriverRepository Drivers { get; }
  IAchievementsRepository Achievements { get; }

  Task<bool> CompleteAsync();
}

