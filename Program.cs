using KantineApp.Data;
using KantineApp.Repository;
using KantineApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<KantineDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IDailySpecialRepository, DailySpecialRepository>();
builder.Services.AddScoped<IWeeklyOfferRepository, WeeklyOfferRepository>();

builder.Services.AddScoped<MenuService>();
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<DailySpecialService>();
builder.Services.AddScoped<WeeklyOfferService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();