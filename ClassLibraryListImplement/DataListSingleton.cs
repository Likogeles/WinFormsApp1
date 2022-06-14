using ClassLibraryListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryListImplement
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<User> Users { get; set; }
        private DataListSingleton()
        {
            Users = new List<User>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
