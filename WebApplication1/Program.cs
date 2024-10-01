using Microsoft.OpenApi.Models;
using WebApplication1.DB;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Simple API",
            Description = "",
            Version = "v1"
        });
    });
}

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple API v1");
});


app.MapGet("/", () => "Hello World!");

app.MapGet("/ctx/{id}", (int id) => CtxDB.GetCtx(id));

app.MapGet("/ctx", () => CtxDB.GetCtxStatic);

app.MapPost("/ctx", (Ctx ctx) => CtxDB.CreateCtx(ctx));

app.MapPut("/ctx", (Ctx ctx) => CtxDB.UpdateCtx(ctx));

app.MapDelete("/ctx", (int id) => CtxDB.DeleteCtx(id));

app.Run();
