
using StoreApi.Constants;
using StoreApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

List<Product> products = new List<Product>() { new() {Name="Tablet",Price=15000000 },new() {Name="Mobile",Price=20000000 },new (){Name="Laptop",Price=30000000 } };

app.MapGet("/Products", () =>
{

    return products;

});

app.MapGet("/Products/{id}", (int id) =>
{
        
    return products.Where(_ => _.Id == id).FirstOrDefault(); ;

});


app.MapPost("/Products", (Product nProduct) => {

    if (products.Exists(p => p.Name.Contains(nProduct.Name))) { 
        return  Results.Conflict(Enums.ProductExists);
    }

    products.Add(nProduct);
    return Results.Created($"/products/{nProduct.Id}",products);


});

 


app.Run();
