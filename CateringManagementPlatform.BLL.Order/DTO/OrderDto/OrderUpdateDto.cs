﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CateringManagementPlatform.BLL.Order.DTO.OrderLineDtos;

namespace CateringManagementPlatform.BLL.Order.DTO.OrderDto
{
    public class OrderUpdateDto
    {
        public int Id { get; set; }

        public DateTime? CheckClosingTime { get; set; }

        [Required]
        public int StatusOrderId { get; set; }

        public int? PaymentTypeId { get; set; }

        //[Required]
        //public int NumberGuests { get; set; }

        public ICollection<OrderLineCreateDto> OrderLines { get; set; } = new List<OrderLineCreateDto>();
    }
}
