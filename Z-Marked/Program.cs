using Z_Lib.Services;
using Z_Marked.Model;
using Z_Marked.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IUserSource>(new UserDB());
builder.Services.AddSingleton<IItemSource>(new ItemRepo());
builder.Services.AddSingleton(new Order());
builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


