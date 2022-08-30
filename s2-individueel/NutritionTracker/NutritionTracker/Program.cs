using DAL.DataContext;
using DAL.Functions.Crud;
using DAL.Functions.Specific;
using DAL.Functions.Specific.IdentityUser;
using DAL.Functions.Specific.UserInfo;
using DALInterfaces.Interfaces;
using LOGIC.Services.Implementation;
using LOGICinterface.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityUser = Microsoft.AspNetCore.Identity.IdentityUser;
using IdentityUsers = DAL.Functions.Specific.IdentityUser.IdentityUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => { options.SignIn.RequireConfirmedAccount = false; }).AddEntityFrameworkStores<DatabaseContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    //options.Cookie.Expiration 

    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/Login";
    options.SlidingExpiration = true;
});

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//DAL
builder.Services.AddScoped<ICrud, Crud>();
builder.Services.AddScoped<IIdentityUser, IdentityUsers>();
builder.Services.AddScoped<IRole, Role>();
builder.Services.AddScoped<IUserInfo, UserInfo>();
builder.Services.AddScoped<IScheme, Scheme>();
builder.Services.AddScoped<ISet, Set>();
builder.Services.AddScoped<IHome, Home>();
builder.Services.AddScoped<INutrition, Nutrition>();

//LOGIC
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserInfoService, UserInfoService>();
builder.Services.AddScoped<ISchemeService, SchemeService>();
builder.Services.AddScoped<IExcersiseService, ExcersiseService>();
builder.Services.AddScoped<ISetService, SetService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<INutritionService, NutritionService>();


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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute("default", "{controller=Account}/{action=Index}/{id?}");

app.Run();