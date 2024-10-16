namespace ConsumirApi_Capitalismo.Services.Interfaces;

public interface IRonSwansonService
{
    Task<string> GetRandomRonSwansonText();
    Task<string> GetRonSwansonId(int id);
    Task<string> GetRonSwansonTerm();
}
