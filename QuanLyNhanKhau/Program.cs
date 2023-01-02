using Microsoft.EntityFrameworkCore;
using QuanLyNhanKhau.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QuanLyNhanKhauConText>(options =>
{
    string conn = builder.Configuration.GetConnectionString("QuanLyNhanKhauDb");
    options.UseSqlServer(conn);
});
builder.Services.AddSession(session =>
{
    session.Cookie.Name = "name";
    session.Cookie.Name = "id";
    session.Cookie.Name = "role";
    session.IdleTimeout = new TimeSpan(0, 60, 0);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
