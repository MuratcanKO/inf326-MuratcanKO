using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Damacana.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Product> CartProducts { get; set; }
    }
}