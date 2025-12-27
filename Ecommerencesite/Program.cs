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
//          app.UseSwagger();
//          app.UseSwaggerUI();
//}


//app.UseAuthorization();

//app.MapControllers();

//app.Run();




using Ecommerencesite.Businee_Layer.BusineeLayer;
using Ecommerencesite.Businee_Layer.BusinessLayer;
using Ecommerencesite.Businee_Layer.IBusineeLayer;
using Ecommerencesite.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// =======================
// SERVICES (BEFORE BUILD)
// =======================

builder.Services.AddCors(options =>
{
          options.AddPolicy("AllowAll", policy =>
          {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
          });
});

builder.Services.AddControllers();

//builder.Services.AddDbContext<Ecommerecewebstedatabase>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnections")
//    )
//);
builder.Services.AddDbContext<Ecommerecewebstedatabase>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

builder.Services.AddScoped<IUserMedicineRepository, UserMedicineRepository>();
builder.Services.AddScoped<IMedicineRepositort, MedicineRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//          c =>
//{
//          c.SwaggerDoc("v1", new OpenApiInfo
//          {
//                    Title = "Ecommerencesite API",
//                    Version = "v1"
//          });
//});

// =======================
// BUILD
// =======================
var app = builder.Build();

// =======================
// MIDDLEWARE (AFTER BUILD)
// =======================

app.UseSwagger();
app.UseSwaggerUI();
//          options =>
//{
//          options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerencesite v1");
//          options.RoutePrefix = "swagger";
//});
app.UseCors("AllowAll");

app.UseAuthorization();
//app.UseStaticFiles();

app.MapControllers();

app.Run();
