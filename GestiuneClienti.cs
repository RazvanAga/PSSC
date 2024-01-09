using System;
using System.Collections.Generic;

namespace PSSC_S3
{
    public class GestiuneClienti
    {
        private List<Client> clienti;

        public GestiuneClienti()
        {
            clienti = new List<Client>();
        }

        public void AdaugaClient(Client client)
        {
            clienti.Add(client);
        }

        public void AfiseazaClienti()
        {
            Console.WriteLine("Lista clientilor:");
            Console.WriteLine("Nume" + "Prenume" + "Telefon");

            foreach (var client in clienti)
            {
                Console.WriteLine($"{client.nume.PadLeft(12)}{client.prenume.PadLeft(12)}{client.telefon.PadLeft(12)}");
            }

        }



        public List<Client> ObtineClienti()
        {
            return clienti;
        }
    }
}
