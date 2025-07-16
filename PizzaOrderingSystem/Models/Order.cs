using System;
using System.Collections.Generic;

namespace PizzaOrderingSystem.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int? EmployeeId { get; set; }

    public int? PizzaId { get; set; }

    public string? OrderStatus { get; set; }

    public decimal? TotalPrice { get; set; }

    public DateTime? DeliveryDateTime { get; set; }

    //    public virtual Customer? Customer { get; set; }

    //    public virtual Employee? Employee { get; set; }

    //    public virtual Pizza? Pizza { get; set; }
}
