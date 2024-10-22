using System;
using System.Collections.Generic;

namespace BussinessObject.DataAccess;

public partial class Role
{
    public int RoleId { get; set; }

    public bool? RoleDesc { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
