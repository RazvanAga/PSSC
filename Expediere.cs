using PSSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSC
{
    public record Expediere(Comanda Comanda)
    {
        public int Id { get; init; }
        public string Status { get; init; }
    }
}