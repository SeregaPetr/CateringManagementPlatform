using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.DAL.Entities
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string NameStatus { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }

    public enum StatusName
    {
        Open = 1,       //счет открыт
        Closed,         //счет закрыт
        NewOrder,       //новый заказ
        WorkOrder,      //заказ в работе
        OrderIsReady,   //заказ готов
        Ordering,       //подача заказа    
        OrderFiled,     //заказ подан
        BillPaid
    }
}