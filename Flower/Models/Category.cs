using System;
using System.Collections.Generic;

namespace Flower.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public bool Status { get; set; }
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
