using System;
using System.Collections.Generic;

namespace WebAPITechProducts.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public decimal Price { get; set; }

    public int? Stock { get; set; }

    public DateTime? CreatedAt { get; set; }
}
