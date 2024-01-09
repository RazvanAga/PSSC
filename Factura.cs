using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSC
{
    public record Factura(Comanda Comanda)
    {
        public int Id { get; init; }
        public decimal Total { get; init; }
    }
}