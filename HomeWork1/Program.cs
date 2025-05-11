using IceCreamStoreRepostery;
using IceCreamStoreService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IIceCreamStoreReposteryUser, IceCreamStoreReposteryUser>();
builder.Services.AddTransient<IIceCreamStoreServiceUser,IceCreamStoreServiceUser>();
// Add services to the container.


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
