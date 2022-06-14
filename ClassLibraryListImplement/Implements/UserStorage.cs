using ClassLibraryContracts.BindingModels;
using ClassLibraryContracts.StoragesContracts;
using ClassLibraryContracts.ViewModels;
using ClassLibraryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryListImplement.Implements
{
    public class UserStorage : IUserStorage
    {
        private readonly DataListSingleton source;
        public UserStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<UserViewModel> GetFullList()
        {
            return source.Users.Select(CreateModel).ToList();
        }
        public List<UserViewModel> GetFilteredList(UserBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Users.Where(rec => rec.Name.Contains(model.Name)).Select(CreateModel).ToList();
        }
        public UserViewModel GetElement(UserBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var user = source.Users.FirstOrDefault(rec => rec.Name == model.Name || rec.Id == model.Id);
            return user != null ? CreateModel(user) : null;
        }
        public void Insert(UserBindingModel model)
        {
            int maxId = source.Users.Count > 0 ? source.Users.Max(rec => rec.Id) : 0;
            var element = new User
            {
                Id = maxId + 1,
            };
            source.Users.Add(CreateModel(model, element));
        }
        public void Update(UserBindingModel model)
        {
            var element = source.Users.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(UserBindingModel model)
        {
            User element = source.Users.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Users.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static User CreateModel(UserBindingModel model, User component)
        {
            component.Name = model.Name;
            component.Password = model.Password;
            return component;
        }
        private static UserViewModel CreateModel(User component)
        {
            return new UserViewModel
            {
                Id = component.Id,
                Name = component.Name,
                Password = component.Password,
            };
        }
    }
}
