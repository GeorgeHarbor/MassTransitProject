namespace FormulaOne.Entities.Dtos.Requests;

public class CreateDriverRequest
{

  public string FirstName { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public int DriversNumber { get; set; }
  public DateTime DateOfBirth { get; set; }
}
