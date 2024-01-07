using System;
using System.Collections.Generic;
using System.Text;
using static PSSC_S3.StareCos;

namespace PSSC_S3
{
    public static class ComandaOperation
    {
        public static IStarecos ValidareComanda(Func<int, bool> checkProdusExists, NevalidatStareCos comanda)
        {
            int produse = 0;
            List<Produs> produse1 = new List<Produs>();
            foreach (var produs in comanda.Produse)
            {
                produse1.Add(produs);
                produse++;
            }
            if (produse <= 0)
            {
                return new GolStareCos(comanda.Client, produse1);
            }
            else if (comanda.Client == null)
            {
                return new NevalidatStareCos(comanda.Client, produse1);
            }
            else
            {
                return new ValidatStareCos(comanda.Client, produse1);
            }
        }

        public static IStarecos PublicareComanda(IStarecos comanda) => comanda.Match(
            whenNevalidatStareCos: nevalidatCos => nevalidatCos,
            whenGolStareCos: golCos => golCos,
            whenPublicatStareCos: publicatCos => publicatCos,
            whenValidatStareCos: validatCos =>
            {
                StringBuilder csv = new StringBuilder();
                validatCos.Produse.Aggregate(csv, (export, produs) =>
                    export.AppendLine($"{produs.Cod}, {produs.Cantitate}, {produs.Denumire}"));
                PublicatStareCos comandaPublicata = new PublicatStareCos(validatCos.Client, validatCos.Produse, csv.ToString(), DateTime.Now);

                return comandaPublicata;
            });
    }
}
