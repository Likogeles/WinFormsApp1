
using System.Collections.Generic;
using ClassLibraryContracts.ViewModels;
using ClassLibraryContracts.BindingModels;

namespace ClassLibraryContracts.StoragesContracts
{
    public interface IUserStorage
    {
        List<UserViewModel> GetFullList();
        List<UserViewModel> GetFilteredList(UserBindingModel model);
        UserViewModel GetElement(UserBindingModel model);
        void Insert(UserBindingModel model);
        void Update(UserBindingModel model);
        void Delete(UserBindingModel model);
    }
}
