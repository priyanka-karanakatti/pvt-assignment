using Microsoft.EntityFrameworkCore;
using PTVGroupRepository;
using PTVGroupRepository.Data;
using PTVGroupRepository.Interfaces;
using PTVGroupService;
using PTVGroupService.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

//to add swagger config
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IStreetRepository, StreetRepository>();
builder.Services.AddTransient<IStreetService, StreetService>();

////Database 
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("PtvDbConnectionString")));


builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
// Configure the HTTP request pipeline.


var app = builder.Build();

Console.WriteLine(app.Environment);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();

