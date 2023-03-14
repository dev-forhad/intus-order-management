namespace BlazorFullStackCrud.Shared.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public List<WindowDTO> Windows { get; set; } = new List<WindowDTO>();
    }

}
