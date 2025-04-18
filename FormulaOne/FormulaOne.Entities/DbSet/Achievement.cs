namespace FormulaOne.Entities.DbSet;

public class Achievement : BaseEntity
{
  public int RaceWins { get; set; }
  public int PolePosition { get; set; }
  public int FastestLap { get; set; }
  public int WorrldChampionship { get; set; }
  public Guid Driverid { get; set; }

  public virtual Driver? Driver { get; set; }
}
