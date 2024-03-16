
using Microsoft.Extensions.Configuration;
using StoreApi.Constants;
using StoreApi.MessageHandler;
using StoreApi.Model;
using StoreApi.Repo;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<MessageBrokerHandler>(builder.Configuration.GetSection("RabbitMQ"));
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

var Products = DbContext.Products();
var Users = DbContext.Users();
var DiscountCodes = DbContext.DiscountCodes();
var Invoices = DbContext.Invoices();

app.MapGet("/Users", () => { var mesg =new MessageBrokerHandler(builder.Configuration);
    var connection = mesg.ConnectMq();
    using var channel = connection.CreateModel();
    const string message = "Hello World!";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish(exchange: "Stock_Exchange",
                         routingKey: "Transferer", mandatory:false,
                         basicProperties: null,
                         body: body);
    return Users; });
app.MapGet("/Users/{id}", (int id) =>{
    return Users.Where(x => x.Id == id).FirstOrDefault();
});
app.MapPost("/Users", (User user) => { 
    Users.Add(user);
    return Results.Created($"/Users/{user.Id}",Users);
});
app.MapGet("/Products", () =>{ return Products;});
app.MapGet("/Products/{id}", (int id) =>{return Products.Where(_ => _.Id == id).FirstOrDefault(); });
app.MapPost("/Products", (Product nProduct) => {
    Products.Add(nProduct);
    return Results.Created($"/Products/{nProduct.Id}",Products);
});
app.MapGet("/Discounts", ()=> { return DiscountCodes; });
app.MapGet("/Discount/{id}", (int id) =>{return DiscountCodes.Where(_ => _.Id == id).FirstOrDefault();});
app.MapPost("/Discounts", (DiscountCode discountCode) => {

    DiscountCodes.Add(discountCode);
    return Results.Created($"/Discount/{discountCode.Id}",DiscountCodes);

});
app.MapGet("/Invoices", () => { return Invoices; });
app.MapGet("/Invoices/{id}", (int id) => { return Invoices.Where(_=>_.Id==id).FirstOrDefault(); });
app.MapPost("/Invoices", (Invoice invoice) => {
    Invoices.Add(invoice);
    return Results.Created($"/Invoices/{invoice.Id}", Invoices); 
    });

app.Run();
