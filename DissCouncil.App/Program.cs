using DissCouncil.Persistence;
using DissCouncil.App.Services;
using DissCouncil.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

//создание строителя приложения 
var builder = WebApplication.CreateBuilder(args);

//добавление сервисов (что приложение умеет делать - регистрирование способностей)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters
            .Add(new System.Text.Json.Serialization.JsonStringEnumConverter()));
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IDissertationRepository, DissertationRepository>();
builder.Services.AddScoped<IDissertationService, DissertationService>();

//сбор инфы про эндпоинты
builder.Services.AddEndpointsApiExplorer();
// генерация описания по этой инфе
builder.Services.AddSwaggerGen();

// граница (собираем все регистрации в готовое приложение)
var app = builder.Build();  // готовое приложение из всех регистраций

// middleware-конвейер (она же цепочка обработчиков запроса)
app.UseHttpsRedirection();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

// запуск приложения
app.Run();