using DissCouncil.Persistence;
using Microsoft.EntityFrameworkCore;

//создание строителя приложения 
var builder = WebApplication.CreateBuilder(args);

//добавление сервисов (что приложение умеет делать - регистрирование способностей)
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// граница (собираем все регистрации в готовое приложение)
var app = builder.Build();  // готовое приложение из всех регистраций

// middleware-конвейер (она же цепочка обработчиков запроса)
app.UseHttpsRedirection();
app.MapControllers();

// запуск приложения
app.Run();