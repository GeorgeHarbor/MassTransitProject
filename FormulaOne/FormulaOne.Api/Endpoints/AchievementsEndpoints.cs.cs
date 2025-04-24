using AutoMapper;
using FormulaOne.DataService;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;

namespace FormulaOne.Api.Endpoints;

public static class AchievementsEndpoints
{
  public static void MapAchievementsEndPoints(this IEndpointRouteBuilder app)
  {
    app.MapGet("/api/achievements/{driverId}", GetDriverAchievements);
    app.MapPost("/api/achievements/", AddAchievement);
  }

  public static async Task<IResult> GetDriverAchievements(IUnitOfWork unitOfWork, IMapper mapper, Guid driverId)
  {
    var driverAchievements = await unitOfWork.Achievements.GetDriverAchievementAsync(driverId);

    if (driverAchievements == null)
      return Results.NotFound("Achievements not found");

    var result = mapper.Map<DriverAchievementResponse>(driverAchievements);

    return Results.Ok(result);
  }

  public static async Task<IResult> AddAchievement(CreateDriverAchievementRequest request,
                                                   IUnitOfWork unitOfWork,
                                                   IMapper mapper)
  {
    var achievement = mapper.Map<Achievement>(request);
    await unitOfWork.Achievements.Add(achievement);
    var result = await unitOfWork.CompleteAsync();

    return result ? TypedResults.Created() : Results.BadRequest();
  }

}
