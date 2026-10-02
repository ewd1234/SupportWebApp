using System.Threading.Tasks;
using SupportWebApp.Models;

namespace SupportWebApp.Services
{
    public interface ICosmosDbService
    {
        Task AddSupportMessageAsync(SupportMessage message);
        Task<List<SupportMessage>> GetSupportMessagesAsync();
        Task<List<SupportMessage>> GetSupportMsgByCategoryAsync(string category);
    }
}