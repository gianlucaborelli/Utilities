using Api.IsTempMail.Service;
using Api.Utilities.Domain.Models;
using Api.Utilities.Domain.Repository;

namespace Api.Utilities.Services
{
    public class EmailProviderService : IEmailProviderService
    {
        private readonly IEmailProviderRepository _repository;
        private readonly IIsTempMailService _isTempMailService;

        public EmailProviderService(IEmailProviderRepository repository, IIsTempMailService isTempMailService)
        {
            _repository = repository;
            _isTempMailService = isTempMailService;
        }        

        public async Task<bool> CheckEmailProvider(string domain)
        {
            if (await _repository.GetByName(domain) is not null) return false;


            if ((await _isTempMailService.CheckEmailProviderOnline(domain)).IsNotBlocked())
                return true;

            await _repository.InsertAsync(new EmailProvider(domain));

            return false;
        }
    }
}