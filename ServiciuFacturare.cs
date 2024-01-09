using PSSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSC
{
    public class ServiciuFacturare
    {
        public Factura GenereazaFactura(Comanda comanda)
        {
            decimal totalFactura = 0;

            foreach (var produs in comanda.Produse)
            {
                totalFactura += produs.Cantitate.GetIntValue() * produs.Pret;
            }

            var factura = new Factura(comanda)
            {
                Total = totalFactura
            };

            FaraDB.Facturi.Add(factura);

            return factura;
        }
    }
}
