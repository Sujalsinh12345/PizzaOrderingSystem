using System;
using System.Collections.Generic;

namespace PizzaOrderingSystem.Models;

public partial class Admin
{
    public int AdId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }
}
