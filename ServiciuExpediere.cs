using PSSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSC
{
    public class ServiciuExpediere
    {
        public Expediere ExpedieazaComanda(Comanda comanda)
        {
            string statusExpediere = "In curs de procesare";

            var expediere = new Expediere(comanda)
            {
                Status = statusExpediere
            };

            FaraDB.Expedieri.Add(expediere);

            return expediere;
        }
    }
}
