using LibrarySystem;
using LibrarySystem.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();

// 这里已经没有任何app.MapPost借书相关代码

app.Run();
