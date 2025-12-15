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

// =======================
// SERVICES
// =======================

// CORS
builder.Services.AddCors(options =>
{
          options.AddPolicy("AllowAll", policy =>
          {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
          });
});

// Controllers
builder.Services.AddControllers();

// Database
builder.Services.AddDbContext<Ecommerecewebstedatabase>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Ecommerecewebstedatabasecontext")
    )
);

// Dependency Injection
builder.Services.AddScoped<IUserMedicineRepository, UserMedicineRepository>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Kestrel (Railway / Docker friendly)
//builder.WebHost.ConfigureKestrel(options =>
//{
//          options.ListenAnyIP(8080);
//});

// =======================
// BUILD APP (ONLY ONCE)
// =======================
var app = builder.Build();

// =======================
// MIDDLEWARE
// =======================
if (app.Environment.IsDevelopment())
{
          app.UseSwagger();
          app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.MapControllers();

// =======================
// RUN
// =======================
app.Run();
