using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSC
{
    public enum StareComanda
    {
        InAsteptare,
        InProcesare,
        Finalizata,
        Anulata
    }

    public record StatusComanda(StareComanda Stare);
}
