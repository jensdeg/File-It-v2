using CommentServiceAPI.Interface;
using CommentServiceAPI.Messaging;
using CommentServiceAPI.Repos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

MockCommentRepo commentrepo = new(); //mock repository

builder.Services.AddScoped<ICommentRepository>(provider => {
    return commentrepo;
});

var app = builder.Build();

ReceiveMessage.createChannel(commentrepo, builder.Configuration);

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
