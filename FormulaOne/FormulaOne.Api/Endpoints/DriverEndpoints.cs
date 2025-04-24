using AutoMapper;
using FormulaOne.DataService;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;

namespace FormulaOne.Api.Endpoints;

public static class DriverEndpoints
{
  public static void MapDriverEndpoints(this IEndpointRouteBuilder app)
  {
    app.MapGet("/api/drivers", GetDrivers).WithName("GetDrivers");
    app.MapGet("/api/drivers/{id}", GetDriver).WithName("GetDriver");
    app.MapPost("/api/driver/", AddDriver);
  }

  public static async Task<IResult> GetDrivers(IUnitOfWork unitOfWork)
  {
    var result = await unitOfWork.Drivers.All();
    return Results.Ok(result);
  }

  public static async Task<IResult> GetDriver
    (
     IUnitOfWork unitOfWork,
     Guid id
    )
  {
    var result = await unitOfWork.Drivers.GetById(id);
    if (result is not null)
      return Results.Ok(result);

    return Results.NotFound();
  }

  public static async Task<IResult> AddDriver(CreateDriverRequest request,
                                              IUnitOfWork unitOfWork,
                                              IMapper mapper)
  {
    var driver = mapper.Map<Driver>(request);
    await unitOfWork.Drivers.Add(driver);
    var result = unitOfWork.CompleteAsync();

    return TypedResults.Ok(result);
  }
}
