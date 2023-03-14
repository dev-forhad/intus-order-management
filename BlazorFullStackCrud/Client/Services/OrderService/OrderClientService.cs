using BlazorFullStackCrud.Client.Pages;
using BlazorFullStackCrud.Shared.DTO;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorFullStackCrud.Client.Services.SuperHeroService
{
    public class OrderClientService : IOrderClientService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;
        public List<OrderDTO> OrdersList { get; set; } = new List<OrderDTO>();

        public OrderClientService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<OrderDTO> Orders { get; set; } = new List<OrderDTO>();

        public async Task<List<OrderDTO>> GetOrders()
        {
            var result = await _http.GetFromJsonAsync<List<OrderDTO>>("api/order/orders");
            if (result != null)
                Orders = result;
            return Orders;
        }

        public async Task<OrderDTO> GetSingleOrders(int id)
        {
            var result = await _http.GetFromJsonAsync<OrderDTO>($"api/order/{id}");
            if (result != null)
                return result;
            throw new Exception("Hero not found!");
        }


        // Create method for creating a new order in the database

        public async Task CreateOrder(OrderDTO order)
        {
            await _http.PostAsJsonAsync("api/order", order);
            _navigationManager.NavigateTo("order-index");
        }


        // Update method for updating an existing order in the database
        public async Task UpdateOrder(OrderDTO order)
        {
            await _http.PutAsJsonAsync($"api/order/{order.Id}", order);
            _navigationManager.NavigateTo("order-index");
        }

        public async Task DeleteOrder(int id)
        {
            await _http.DeleteAsync($"api/order/{id}");
            _navigationManager.NavigateTo("order-index");
        }
        
        public async Task DeleteWindow(int id)
        {
            await _http.DeleteAsync($"api/order/window-delete/{id}");
        }

        public async Task DeleteSubElement(int id)
        {
            await _http.DeleteAsync($"api/order/subelement-delete/{id}");
        }

        public  async Task GoOrderIndex(string path)
        {
            _navigationManager.NavigateTo(path);
        }
    }
}
