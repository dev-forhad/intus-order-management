

using BlazorFullStackCrud.Shared.DTO;


namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public interface IOrderClientService
    {
        List<OrderDTO> OrdersList { get; set; }
        List<OrderDTO> Orders { get; set; }
        Task<List<OrderDTO>> GetOrders();
        Task<OrderDTO> GetSingleOrders(int id);
        Task CreateOrder(OrderDTO order);
        Task UpdateOrder(OrderDTO order);
        Task DeleteOrder(int id);
        Task DeleteWindow(int id);
        Task DeleteSubElement(int id);
        Task GoOrderIndex(string path);
    }
}
