using System;
using System.Collections.Generic;
using System.Text;

namespace CateringManagementPlatform.BLL.DTO
{
    public class OrderLineDto
    {
        public int Id { get; set; }
        public int NumberPortions { get; set; }
        public decimal AmountOrderLine { get; set; }

        //public int? StatusId { get; set; }
        //public Status Status { get; set; }
        //public int DishId { get; set; }
        //public Dish Dish { get; set; }
        //public int OrderId { get; set; }
        //public Order Order { get; set; }
    }
}
