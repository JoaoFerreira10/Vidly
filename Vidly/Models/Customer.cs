using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]// include System.ComponentModel.DataAnnotations
        [StringLength(255)]
        public String Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MembershipType MemberShipType { get; set; }
        public byte MemberShipTypeId { get; set; }
        public String birthday { get; set; }
    }
}