using IceCreamStoreRepostery;

using IceCreamStoreService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IIceCreamStoreReposteryUser, IceCreamStoreReposteryUser>();
builder.Services.AddTransient<IIceCreamStoreServiceUser,IceCreamStoreServiceUser>();
builder.Services.AddTransient<IIceCreamStoreReposteryOrder, IceCreamStoreReposteryOrder>();
builder.Services.AddTransient<IIceCreamStoreServiceOrder, IceCreamStoreServiceOrder>();
builder.Services.AddTransient<IIceCreamStoreReposteryCategory, IceCreamStoreReposteryCategory>();
builder.Services.AddTransient<IIceCreamStoreServiceCategory, IceCreamStoreServiceCategory>();
builder.Services.AddTransient<IIceCreamStoreReposteryProduct, IceCreamStoreReposteryProduct>();
builder.Services.AddTransient<IIceCreamStoreServiceProduct, IceCreamStoreServiceProduct>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<WebApiContext>(options => options.UseSqlServer
("Data Source=LAPTOP-MOJ9OFNQ;Initial Catalog=WebApi;Integrated Security=True;TrustServerCertificate=True;Pooling=False"
));

// Add services to the container.


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.MapOpenApi();

    app.UseSwagger();
    app.UseSwaggerUI();


}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
