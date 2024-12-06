using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulzer.Domain.Entities
{
    public class Price
    {
        public decimal Net {  get; set; }
        public decimal Gross { get; set; }

        public Price(decimal net, decimal gross)
        {
            Net = net;
            Gross = gross;
        }
    }
}
