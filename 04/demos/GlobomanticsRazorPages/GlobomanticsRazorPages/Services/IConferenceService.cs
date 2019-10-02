using System.Collections.Generic;
using System.Threading.Tasks;
using GlobomanticsRazorPages.Models;

namespace GlobomanticsRazorPages.Services
{
    public interface IConferenceService
    {
        Task<IEnumerable<ConferenceModel>> GetAll();
        Task<ConferenceModel> GetById(int id);
        Task Add(ConferenceModel model);
    }
}