namespace DissCouncil.Domain.Enums;

public enum DefenseStatus
{
    Scheduled, // еще не прошла
    Successful,  
    Failed,  // не хватило голосов "ЗА"
    Postponed,  // перенесена
    Cancelled  // отменена
}