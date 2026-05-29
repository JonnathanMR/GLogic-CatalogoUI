using System;
using System.Collections.Generic;

namespace CatalogoRopaUI.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public int? IdSubCategoria { get; set; }

    public string? NombreProducto { get; set; }

    public int? Precio { get; set; }

    public int? Stock { get; set; }
}
