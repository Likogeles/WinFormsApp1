using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryContracts.BindingModels
{
    public class UserBindingModel
    {
        public int? Id { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
    }
}
