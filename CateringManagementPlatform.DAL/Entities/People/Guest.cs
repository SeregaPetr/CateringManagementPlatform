using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CateringManagementPlatform.DAL.Entities.People
{
    [Table("Guests")]
    public class Guest : Person
    {
        public int Agg { get; set; }
    }
}
