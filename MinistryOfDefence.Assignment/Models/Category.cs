using System;
using System.Collections.Generic;

namespace MinistryOfDefence.Assignment.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string NameHeb { get; set; } = null!;
}
