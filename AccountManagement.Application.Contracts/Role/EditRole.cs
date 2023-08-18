using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contracts.Role;


public class EditRole : CreateRole
{
    public EditRole()
    {
        Permissions = new List<int>();
    }

    public long Id { get; set; }
    //public List<PermissionDto> MappedPermissions { get; set; }
}
