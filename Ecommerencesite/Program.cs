//using Ecommerencesite.DAL;
//using Ecommerencesite.Database;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//builder.Services.AddDbContext<Ecommerecewebstedatabase>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections")));

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
//void ConfigureServices(IServiceCollection services)
//{
//          services.AddTransient<DALMODEL>();
//          // other services
//}

//app.UseAuthorization();

//app.MapControllers();

//app.Run();


//using Ecommerencesite.DAL;
using Ecommerencesite.Businee_Layer.BusineeLayer;
using Ecommerencesite.Businee_Layer.BusinessLayer;
using Ecommerencesite.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
          options.AddPolicy("AllowAll",
              builder =>
              {
                        builder.AllowAnyOrigin()
                         .AllowAnyMethod()
                         .AllowAnyHeader();
              });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<Ecommerecewebstedatabase>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Ecommerecewebstedatabasecontext")));
builder.Services.AddScoped<IUserMedicineRepository, UserMedicineRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
          app.UseSwagger();
          app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();