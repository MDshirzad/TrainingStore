
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

List<Product> products = new List<Product>() { new() { Name = "Tablet", Price = 15000000,Id=1 }    ,new() {Name="Mobile",Price=20000000 ,Id=2  }, new (){Name="Laptop",Price=30000000 ,Id=3 } };
var DiscountCodes = new List<DiscountCode>() { new() {Id=1, Percentage = 20, Name = "20per",forProduct=1 }, new() {Id=2 ,Percentage = 10, Name = "10per",forProduct=2 }, new() { Id=3, Percentage = 50, Name = "50per", forProduct = 3 } } ;

app.MapGet("/Products", () =>{ return products;});
app.MapGet("/Products/{id}", (int id) =>{return products.Where(_ => _.Id == id).FirstOrDefault(); });
app.MapPost("/Products", (Product nProduct) => {

    if (products.Exists(p => p.Name.Contains(nProduct.Name))) { 
        return  Results.Conflict(Enums.ProductExists);
    }
    products.Add(nProduct);
    return Results.Created($"/Products/{nProduct.Id}",products);
});
app.MapGet("/Discounts", ()=> { return DiscountCodes; });
app.MapGet("/Discount/{id}", (int id) =>{return DiscountCodes.Where(_ => _.Id == id).FirstOrDefault();});
app.MapPost("/Discounts", (DiscountCode discountCode) => {

    if (DiscountCodes.Exists(_=>_.Name==discountCode.Name))
    {
        return Results.Conflict(Enums.DiscountExists);
    }
    DiscountCodes.Add(discountCode);
    return Results.Created($"/Discount/{discountCode.Id}",DiscountCodes);

});


app.Run();
