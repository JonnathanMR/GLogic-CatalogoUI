using CatalogoRopaUI.Interfaces;
using CatalogoRopaUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel(ILogger<IndexModel> logger, IApiServices apiServices) : PageModel
{
    private readonly ILogger<IndexModel> _logger = logger;
    private readonly IApiServices _apiServices = apiServices;

    public List<Producto> Productos { get; set; } = new();
    public List<Categoria> Categorias { get; set; } = new();
    public List<SubCategoria> SubCategorias { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public int? CategoriaId { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? SubCategoriaId { get; set; }

    public async Task OnGetAsync()
    {
        Categorias = await _apiServices.GetCategoriasAsync();

        if (CategoriaId.HasValue)
        {
            SubCategorias = await _apiServices.GetSubCategoriaByCategoria(CategoriaId.Value);

            if (SubCategoriaId.HasValue)
                // Filtro por subcategoría específica
                Productos = await _apiServices.GetRopaBySubCatetgoriaAsync(SubCategoriaId.Value);
            else
                // Solo categoría → trae todos los productos de esa categoría
                Productos = await _apiServices.GetRopaByCategoriaAsync(CategoriaId.Value);
        }
        else
        {
            // Sin filtros → trae todo
            Productos = await _apiServices.GetRopaAsync();
        }
    }
}