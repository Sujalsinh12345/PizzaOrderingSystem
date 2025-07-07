using System;
using System.Collections.Generic;

namespace PizzaOrderingSystem.Models;

public partial class Topping
{
    public int TpId { get; set; }

    public int? Sprice { get; set; }

    public int? Mprice { get; set; }

    public int? Lprice { get; set; }
}
