namespace Api.Utilities.Services
{
    public interface IEmailProviderService
    {
        Task<bool> CheckEmailProvider (string doamin);
    }
}