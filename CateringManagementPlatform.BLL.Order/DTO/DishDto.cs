namespace CateringManagementPlatform.BLL.Order.DTO
{
    public class DishDto
    {
        public int Id { get; set; }
        public string NameDish { get; set; }
        public string CompositionDish { get; set; }
        public int Weight { get; set; }
        public decimal Price { get; set; }
    }
}
