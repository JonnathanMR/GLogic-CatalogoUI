using CatalogoRopaUI.Models;

namespace CatalogoRopaUI.Interfaces
{
    public interface IApiServices
    {
        Task<List<Categoria>> GetCategoriasAsync();
        Task<List<Producto>> GetRopaAsync();

        Task<List<SubCategoria>> GetSubCategoriaByCategoria(int idCategoria);

        Task<List<Producto>> GetRopaBySubCatetgoriaAsync(int idSubCategoria);

        Task<List<Producto>> GetRopaByCategoriaAsync(int idCategoria);
    }
}
