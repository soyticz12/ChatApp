using ChatAuth.Service;
using Supabase;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped(_ =>
new Client(
    builder.Configuration["Supabase:Url"],
    builder.Configuration["Supabase:Key"],
    new SupabaseOptions
    {
        AutoRefreshToken = true,
        AutoConnectRealtime = true,
    }
));

builder.Services.AddScoped<AuthService>();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable routing to controllers
app.MapControllers(); 

app.Run();
