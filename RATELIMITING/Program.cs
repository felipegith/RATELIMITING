using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Fixed Window Limiter
builder.Services.AddRateLimiter(rl => rl.AddFixedWindowLimiter(policyName: "fixed", opt =>
{
    opt.Window = TimeSpan.FromSeconds(15);
    opt.PermitLimit = 5;
    opt.QueueLimit = 10;
    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
}).RejectionStatusCode = 429);

// Sliding Window Limiter
builder.Services.AddRateLimiter(rl => rl.AddSlidingWindowLimiter(policyName: "sliding", opt =>
{
    opt.Window = TimeSpan.FromSeconds(15);
    opt.PermitLimit = 5;
    opt.QueueLimit = 10;
    opt.SegmentsPerWindow = 5;
    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
}).RejectionStatusCode = 429);

// Token Bucket Limiter
builder.Services.AddRateLimiter(rl => rl.AddTokenBucketLimiter(policyName: "token", opt =>
{
    opt.TokenLimit = 10;
    opt.QueueLimit = 0;
    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    opt.ReplenishmentPeriod = TimeSpan.FromMinutes(1);
    opt.TokensPerPeriod = 1;
    
}).RejectionStatusCode = 429);

// Concurrency Limiter
builder.Services.AddRateLimiter(rl => rl.AddConcurrencyLimiter(policyName: "concurrency", opt =>
{
    opt.QueueLimit = 1;
    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    opt.PermitLimit = 5;

}).RejectionStatusCode = 429);
var app = builder.Build();

app.UseRateLimiter();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
