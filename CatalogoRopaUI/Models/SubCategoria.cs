using System;
using System.Collections.Generic;

namespace CatalogoRopaUI.Models;

public partial class SubCategoria
{
    public int IdSubCategoria { get; set; }

    public int? IdCategoria { get; set; }

    public string? NombreSubCategoria { get; set; }
}
