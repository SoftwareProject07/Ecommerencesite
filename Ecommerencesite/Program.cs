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
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
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
//    options.UseNpgsql(
//        builder.Configuration.GetConnectionString("DefaultConnection")
//    )
//);

builder.Services.AddDbContext<Ecommerecewebstedatabase>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        npgsqlOptions =>
        {
                  npgsqlOptions.CommandTimeout(300); // ⬅️ 3 minutes
        }
    )
);

//optionsBuilder.UseNpgsql(
//    configuration.GetConnectionString("DefaultConnection"),
//    o => o.CommandTimeout(300)
//);

//builder.Services.AddDbContext<Ecommerecewebstedatabase>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection")));




builder.Services.AddScoped<IUserMedicineRepository, UserMedicineRepository>();
builder.Services.AddScoped<IMedicineRepositort, MedicineRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddScoped<IPatient_CustomerRepository, Patient_CustomerRepository>();


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
//app.UseStaticFiles(); // 🔥 REQUIRED for image access
// ✅ STATIC FILES (wwwroot)
//app.UseStaticFiles();

// ✅ UPLOADS FOLDER (CUSTOM)
//app.UseStaticFiles(new StaticFileOptions
//{
//          FileProvider = new PhysicalFileProvider(
//        Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
//          RequestPath = "/uploads"
//});

//var uploadsPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

//if (!Directory.Exists(uploadsPath))
//{
//          Directory.CreateDirectory(uploadsPath);
//}

//app.UseStaticFiles(new StaticFileOptions
//{
//          FileProvider = new PhysicalFileProvider(
//        Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
//          RequestPath = "/uploads"
//});
app.UseSwagger();
app.UseSwaggerUI();
//          options =>
//{
//          options.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecommerencesite v1");
//          options.RoutePrefix = "swagger";
//});
app.UseCors("AllowAll");
app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(
//        Path.Combine(Directory.GetCurrentDirectory(), "uploads")),
//    RequestPath = "/uploads"
//});

app.UseAuthorization();
//app.UseAuthentication();
//app.UseAntiforgery();

app.UseStaticFiles();

app.MapControllers();

app.Run();
