using System;
using System.Collections.Generic;

namespace recipts.Models;

public partial class Ingridient
{
    public int IngridientId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ReceiptIngridient> ReceiptIngridients { get; set; } = new List<ReceiptIngridient>();
}
