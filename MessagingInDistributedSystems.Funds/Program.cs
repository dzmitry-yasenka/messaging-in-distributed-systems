using MessagingInDistributedSystems.Funds.Messages;
using MessagingInDistributedSystems.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMessaging();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("message/send", async (IMessagePublisher messagePublisher) =>
{
    var message = new FundsMessage(123, 10.00m);
    await messagePublisher.PublishAsync("Funds", "FundsMessage", message);
});

app.Run();