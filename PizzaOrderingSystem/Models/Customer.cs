﻿using System;
using System.Collections.Generic;

namespace PizzaOrderingSystem.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Address { get; set; }

    public string? PhoneNo { get; set; }

    public string? City { get; set; }

    public string? Email { get; set; }

    public string? PassWord { get; set; }

    //public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
