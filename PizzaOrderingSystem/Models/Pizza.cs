using System;
using System.Collections.Generic;

namespace PizzaOrderingSystem.Models;

public partial class Pizza
{
    public int PizzaId { get; set; }

    public string? Name { get; set; }

    public string? ImageUrl { get; set; }

    public string? Category { get; set; }

    public decimal? Price { get; set; }

    public int? SmallPrice { get; set; }

    public int? MediumPrice { get; set; }

    public int? LargePrice { get; set; }

    //public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
