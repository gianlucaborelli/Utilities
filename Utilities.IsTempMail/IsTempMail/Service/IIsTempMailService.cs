using Api.IsTempMail.Model;

namespace Api.IsTempMail.Service
{
    public interface IIsTempMailService
    {
        Task<Domain> CheckEmailProviderOnline(string domain);
    }
}