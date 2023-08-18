using _0_Framework.Doamain;
using AccountManagement.Domain.AccountAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role:EntityBase
    {
        protected Role() { }
        public Role(string name)
        {
            Name = name;
            Accounts = new List<Account>();
        }

        public string Name { get; private set; }
        public List<Account> Accounts { get; }


        public void Edit(string name)
        {
            Name = name;
        }
    }
}
