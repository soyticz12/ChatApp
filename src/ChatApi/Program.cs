using ChatApi.Interface;
using ChatApi.Repository;
using Supabase;

var builder = WebApplication.CreateBuilder(args);
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

builder.Services.AddScoped<ConversationRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); 

app.Run();
