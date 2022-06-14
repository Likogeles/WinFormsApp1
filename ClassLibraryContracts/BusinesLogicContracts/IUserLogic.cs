using System.Collections.Generic;
using ClassLibraryContracts.BindingModels;
using ClassLibraryContracts.ViewModels;

namespace ClassLibraryContracts.BusinesLogicContracts
{
    public interface IUserLogic
    {
        List<UserViewModel> Read(UserBindingModel model);
        void CreateOrUpdate(UserBindingModel model);
        void Delete(UserBindingModel model);
    }
}
