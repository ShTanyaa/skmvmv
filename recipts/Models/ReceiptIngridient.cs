using System;
using System.Collections.Generic;

namespace recipts.Models;

public partial class ReceiptIngridient
{
    public int Id { get; set; }

    public int Receipt { get; set; }

    public int Ingridient { get; set; }

    public string Count { get; set; } = null!;

    public virtual Ingridient IngridientNavigation { get; set; } = null!;

    public virtual Receipt ReceiptNavigation { get; set; } = null!;
}
