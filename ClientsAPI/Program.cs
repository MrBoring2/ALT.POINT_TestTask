using ClientsAPI.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using System.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Converters.Add(new StringEnumConverter());
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    //options.SerializerSettings.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
    //options.SerializerSettings.TypeNameAssemblyFormatHandling = Newtonsoft.Json.TypeNameAssemblyFormatHandling.Simple;
});
builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TestTaskClientsContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBaseConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI();
}

else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
