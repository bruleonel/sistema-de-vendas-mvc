using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public List<Produto> Produto { get; set; }
        public Vendedor Vendedor { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
    }
}