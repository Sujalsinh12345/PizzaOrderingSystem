using System;
using System.Collections.Generic;

namespace PizzaOrderingSystem.Models;

public partial class Topping
{
    public int ToppingId { get; set; }

    public string? ToppingName { get; set; }

    public int? SmallPrice { get; set; }

    public int? MediumPrice { get; set; }

    public int? LargePrice { get; set; }
}
