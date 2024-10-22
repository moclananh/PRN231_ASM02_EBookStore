using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BussinessObject.DataAccess;

public partial class User
{
    public int UserId { get; set; }

    public string? EmailAddress { get; set; }

    public string? Password { get; set; }

    public string? Source { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public int? RoleId { get; set; }

    public int? PubId { get; set; }

    public DateTime? HireDate { get; set; }
    [JsonIgnore]
    public virtual Publisher? Pub { get; set; }
    [JsonIgnore]
    public virtual Role? Role { get; set; }
}
