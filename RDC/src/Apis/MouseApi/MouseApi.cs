using Microsoft.AspNetCore.Mvc;
using RDC.src.Apis.Bases;
using RDC.src.Data.DataTypes;
using RDC.src.Data.MouseRepository;

namespace RDC.src.Apis.MouseApi
{
    public class MouseApi : IApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/getMouses", GetAllMouses);
            app.MapPost("/addMouse", AddNewMouse);
        }

        private async Task<IResult> GetAllMouses(IMouseRepository repository)
        {
            return await repository.GetAllMousesAsync() is List<Mouse> mouses
            ? Results.Ok(mouses)
            : Results.NotFound();
        }

        private async Task<IResult> AddNewMouse([FromBody]Mouse newMouse, IMouseRepository repository) 
        {

            await repository.AddMouseAsync(newMouse);
            await repository.SaveAsync();
            return Results.Ok(newMouse);
        }
    }
}
