using System;
using System.Collections.Generic;

namespace MinistryOfDefence.Assignment.Models;

public partial class Item
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public int Amount { get; set; }
}
