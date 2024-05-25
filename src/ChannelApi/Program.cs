using ChannelApi.BackgroundServices;
using ChannelApi.Service.Notification;
using ChannelApi.Service.Report;
using ChannelApi.Service.ReportChannel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IMediaUploader, MediaUploader>();
builder.Services.AddSingleton<IReport, Report>();
builder.Services.AddSingleton<IReportChannel, ReportChannel>();
builder.Services.AddHostedService<ReportConsumer>();

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

app.MapControllers();

app.Run();
