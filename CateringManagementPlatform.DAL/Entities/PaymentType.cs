using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CateringManagementPlatform.DAL.Entities
{
    public class PaymentType
    {
        public int Id { get; set; }
        [Required]
        public string NamePaymentType { get; set; }

        public ICollection<Order> Orders { get; set; }
    }

    public enum PaymentTypeName
    {

    }
}
