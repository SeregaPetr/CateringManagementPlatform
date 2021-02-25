namespace CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos
{
    public class OrderLineReadDto
    {
        public int Id { get; set; }
        public int CountPortions { get; set; }
        public string NameStatus { get; set; }
        public string NameDish { get; set; }
        public decimal PriceDish { get; set; }
        public int NumberTable { get; set; }
        public string FullNameWaiter { get; set; }
    }
}
