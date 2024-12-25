using Abstraction.Contracts;
using Abstraction.Providers;
using AutoMapper;
using Domain.Mapper;
using Domain.Repositories;
using InfraStructure;
using InfraStructure.DB;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    //options.ModelBinderProviders.Insert(0, new m()
    //{
    //    BinderType = typeof(DateOnlyModelBinder)
    //});
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new EmployeeMapperProfile());
    mc.AddProfile(new SalaryMapperProfile());
});
IMapper mapper = mapperConfig.CreateMapper();

builder.Services.AddTransient<IEmployeeContract, EmployeeProvider>();
builder.Services.AddTransient<ISalaryContract, SalaryProvider>();

builder.Services.AddTransient<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddTransient<ISalaryRepo, SalaryRepo>();
builder.Services.AddSingleton(mapper); builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(op => op.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
