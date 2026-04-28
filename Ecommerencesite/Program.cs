
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
using System;

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


//// 1. CORS Policy mein dono URLs add karein
//builder.Services.AddCors(options => {
//          //AllowAll
//          options.AddPolicy("AllowMultiOrigins", policy => {
//                    policy.WithOrigins(
//                            "http://localhost:5173",
//                            "https://medicineavaialblestore.vercel.app"
//                          )
//                          .AllowAnyMethod()
//                          .AllowAnyHeader()
//                          .AllowCredentials(); // Authentication cookies ke liye zaroori
//          });
//});

builder.Services.AddControllers();



builder.Services.AddDbContext<Ecommerecewebstedatabase>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));



//optionsBuilder.UseNpgsql(
//    configuration.GetConnectionString("DefaultConnection"),
//    o => o.CommandTimeout(300)
//);

//builder.Services.AddDbContext<Ecommerecewebstedatabase>(options =>
//    options.UseSqlServer(
//        builder.Configuration.GetConnectionString("DefaultConnection")));


//builder.Services.AddAuthentication("Bearer")
//.AddJwtBearer(options =>
//{
//          options.TokenValidationParameters = new TokenValidationParameters
//          {
//                    ValidateIssuer = true,
//                    ValidateAudience = true,
//                    ValidateLifetime = true,
//                    ValidateIssuerSigningKey = true,
//                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
//                    ValidAudience = builder.Configuration["Jwt:Audience"],
//                    IssuerSigningKey = new SymmetricSecurityKey(
//                  Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])
//              )
//          };
//});

//app.UseAuthentication();
//app.UseAuthorization();


builder.Services.AddScoped<IUserMedicineRepository, UserMedicineRepository>();
builder.Services.AddScoped<IMedicineRepositort, MedicineRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

builder.Services.AddScoped<IFeedbackCusotmerRepository, FeedbackCusotmerRepository>();
builder.Services.AddScoped<ICustomerHelpIssueRepository, CustomerHelpIssueRepository>();
builder.Services.AddScoped<ICustomerAddMedicineRepositorycs, CustomerAddMedicineRepository>();
builder.Services.AddScoped<IPatient_CustomerRepository, Patient_CustomerRepository>();
builder.Services.AddScoped<IBankdetailsRepository, BankdetailsRepository>();
builder.Services.AddScoped<IbankselectmodelsRepository, bankselectmodelsRepository>();
builder.Services.AddScoped<IQRCASHREPOSITORY, QRCASHREPOSITORY>();
builder.Services.AddScoped<ICustomerCareticketrepository ,CustomerCareticketrepository>();
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



app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.UseHttpsRedirection();


app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
