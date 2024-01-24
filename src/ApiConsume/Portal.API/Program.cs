using Portal.BusinessLayer.Abstract;
using Portal.BusinessLayer.Concrete;
using Portal.DataAccessLayer.Abstract;
using Portal.DataAccessLayer.Concrete;
using Portal.DataAccessLayer.EntityFramework;
using Portal.EntityLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(
options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true).AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);



builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAppUserDal, EfAppUserDal>();
builder.Services.AddScoped<IAppUserService, AppUserManager>();
builder.Services.AddScoped<IAppUserProfileDal, EfAppUserProfileDal>();
builder.Services.AddScoped<IAppUserProfileService, AppUserProfileManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<ICategoryDal, EfCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IEducationDal, EfEducationDal>();
builder.Services.AddScoped<IEducationService, EducationManager>();
builder.Services.AddScoped<ITeacherDal, EfTeacherDal>();
builder.Services.AddScoped<ITeacherService, TeacherManager>();
builder.Services.AddScoped<ITeacherInfoDal, EfTeacherInfoDal>();
builder.Services.AddScoped<ITeacherInfoService, TeacherInfoManager>();
builder.Services.AddScoped<IUserEducationDal, EfUserEducationDal>();
builder.Services.AddScoped<IUserEducationService, UserEducationManager>();



builder.Services.AddCors(opt =>
{
    opt.AddPolicy("PortalApi", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); //you can get permission every header,method, and more, consume edeceðim alanlar

    });
}); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
//app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseCors("PortalApi");
app.Run();



