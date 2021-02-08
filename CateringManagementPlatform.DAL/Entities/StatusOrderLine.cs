using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.DAL.Entities
{
    public class StatusOrderLine
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NameStatus { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }

    public enum StatusNameOrderLine
    {
        NewOrder = 1,       //новый заказ
        WorkOrder,      //заказ в работе
        OrderIsReady,   //заказ готов
        Ordering,       //подача заказа    
        OrderFiled,     //заказ подан
    }
}
