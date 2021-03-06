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

    public enum NameStatusOrderLine
    {
        NewOrder = 1,   //новый заказ     ->bar, Kitchen, user
        WorkOrder,      //заказ в работе  ->bar ||(&&) Kitchen, user
        OrderIsReady,   //заказ готов     ->waiters, bar || Kitchen, user
        Ordering,       //подача заказа   ->waiters, user
        OrderFiled,     //заказ подан     ->waiters, user
        Cancelled       //отмененный заказ
    }
}
