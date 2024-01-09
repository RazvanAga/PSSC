using static PSSC_S3.PublicareComandaEvent;
using System;
using static PSSC_S3.StareCos;
using static PSSC_S3.ComandaOperation;

namespace PSSC_S3
{
    public class PublicareComandaWorkflow
    {
        public IPublicareComandaEvent Execute(PublicareComandaCommand command, Func<int, bool> checkProdusExists)
        {
            NevalidatStareCos comandanevalidata1 = new(command.InputClient, command.InputProduse);
            IStarecos comanda = ValidareComanda(checkProdusExists, comandanevalidata1);
            comanda = PublicareComanda(comanda);



            return comanda.Match(
                    whenNevalidatStareCos: unvalidatedComanda => new ComandaPublicareFailEvent("Stare invalida") as IPublicareComandaEvent,
                    whenGolStareCos: golComanda => new ComandaPublicareFailEvent("Cosul este gol"),
                    whenValidatStareCos: validatResult => new ComandaPublicareFailEvent("Cosul nu a fost publicat"),
                    whenPublicatStareCos: publicatCos => new ComandaPublicareSucceedEvent(publicatCos.Csv, publicatCos.PublishedDate)
                    );


        }
    }
}