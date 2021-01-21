namespace CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos
{
    public class OrderLineReadDto
    {
        public int Id { get; set; }
        public int NumberPortions { get; set; }
        public string NameStatus { get; set; }
        public string NameDish { get; set; }
        public decimal PriceDish { get; set; }
    }
}
