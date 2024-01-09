using PSSC_S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSC
{
    public record Comanda(List<Produs> Produse, string NumeClient)
    {
        public int Id { get; init; }
    }
}