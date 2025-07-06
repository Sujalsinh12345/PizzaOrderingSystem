using System;
using System.Collections.Generic;

namespace PizzaOrderingSystem.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public string? Fname { get; set; }

    public string? Lname { get; set; }

    public string? Address { get; set; }

    public string? PhoneNo { get; set; }

    public string? City { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
