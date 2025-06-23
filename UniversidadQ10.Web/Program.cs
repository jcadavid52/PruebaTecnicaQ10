using Microsoft.EntityFrameworkCore;
using UniversidadQ10.Aplication.Registration;
using UniversidadQ10.Aplication.Student;
using UniversidadQ10.Aplication.Subject;
using UniversidadQ10.Domain.Ports;
using UniversidadQ10.Infrastructure.DataSource;
using UniversidadQ10.Infrastructure.Extensions;
using UniversidadQ10.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDomainServices();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("db")));
builder.Services.AddScoped(typeof(IStudentService), typeof(StudentService));
builder.Services.AddScoped(typeof(ISubjectService), typeof(SubjectService));
builder.Services.AddScoped(typeof(IRegistrationService), typeof(RegistrationService));
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseMiddleware<AppExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
