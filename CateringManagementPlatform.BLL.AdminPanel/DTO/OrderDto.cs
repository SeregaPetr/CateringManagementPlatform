using System;

namespace CateringManagementPlatform.BLL.AdminPanel.DTO
{
    public class OrderDto //TODO не проверял
    {
        public int Id { get; set; }
        public DateTime OpeningTimeCheck { get; set; }
        public DateTime? СlosingЕimeСheck { get; set; }
        public decimal AmountOrder { get; set; }
        public string Comment { get; set; }
    }
}
