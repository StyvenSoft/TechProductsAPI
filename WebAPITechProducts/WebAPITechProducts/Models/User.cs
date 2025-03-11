using System;
using System.Collections.Generic;

namespace WebAPITechProducts.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Passwd { get; set; } = null!;

    public DateTime? RegistrationDate { get; set; }

    public bool? StatusUser { get; set; }
}
