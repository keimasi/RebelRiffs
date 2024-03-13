using Framework.Application;
using MusicManagement.Infrastructure.Config;
using ServiceHost;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DbKey1");

MusicMangementBootstrapper.Configure(builder.Services,connectionString);

builder.Services.AddTransient<IFileUpload, FileUpload>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
