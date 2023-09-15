using Web.Models;

namespace Web.Interfaces
{
    public interface IHomeViewModelService
    {
        public Task<HomeViewModel> GetHomeViewModelAsync();
    }
}
