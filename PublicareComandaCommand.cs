using PSSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PSSC_S3.StareCos;

namespace PSSC_S3
{
    public record PublicareComandaCommand
    {
        public PublicareComandaCommand(Client inputClient, List<Produs> inputProduse, StatusComanda inputStatus)
        {
            InputClient = inputClient;
            InputProduse = inputProduse;
            InputStatus = inputStatus;

        }
        public Client InputClient {get; }
        public List<Produs> InputProduse {get; }
        public StatusComanda InputStatus { get;}
    }
}