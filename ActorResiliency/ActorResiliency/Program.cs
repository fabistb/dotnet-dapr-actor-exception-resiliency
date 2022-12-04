using ActorResiliency.Actors;
using ActorResiliency.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddDapr();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IActorFactory<IActorOne>, ActorFactory<IActorOne>>();
builder.Services.AddTransient<IActorFactory<IActorTwo>, ActorFactory<IActorTwo>>();

builder.Services.AddDaprSidekick(builder.Configuration);

builder.Services.AddActors(o =>
{
    o.Actors.RegisterActor<ActorOne>();
    o.Actors.RegisterActor<ActorTwo>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.UseEndpoints(e =>
{
    e.MapControllers();
    e.MapActorsHandlers();
});

app.Run();