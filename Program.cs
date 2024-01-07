using System;
using System.Collections.Generic;
using static PSSC_S3.StareCos;
using static PSSC_S3.Cantitate;

namespace PSSC_S3
{
    public class Program
    {
        static void Main(string[] args)
        {
            Produs produs1 = new Produs(new Cantitate.CantitateKg(2), "cod1", "paine");
            Produs produs2 = new Produs(new Cantitate.CantitateUnitati(4), "cod2", "lapte");
            Produs produs3 = new Produs(new Cantitate.CantitateKg(8), "cod3", "oua");
            Client client1 = new Client("Razvan", "Aga", "420");
            Client client2 = new Client("Andrei", "Aungurencei", "818");
            Client client3 = new Client("Iasmina", "Iacob", "822");

            List<Produs> Produse = new List<Produs>();
            Produse.Add(produs1);
            Produse.Add(produs2);
            Produse.Add(produs3);

            PublicareComandaCommand command1 = new(client1, Produse);
            PublicareComandaCommand command2 = new(client2, Produse);
            PublicareComandaCommand command3 = new(client3, Produse);
            PublicareComandaWorkflow workflow = new PublicareComandaWorkflow();

            var result1 = workflow.Execute(command1, (var) => true);
            var result2 = workflow.Execute(command2, (var) => true);
            var result3 = workflow.Execute(command3, (var) => true);

            result1.Match(
                whenComandaPublicareFailEvent: @event =>
                {
                    Console.WriteLine($"Publish failed: {@event.Reason}");
                    return @event;
                },
                whenComandaPublicareSucceedEvent: @event =>
                {
                    Console.WriteLine($"Publish succeeded.");
                    Console.WriteLine(@event.Csv);
                    return @event;
                }
            );

            List<Produs> comandaClient = new List<Produs>();


            foreach (var produs in Produse)
            {
                Console.Write($"Introduceti cantitatea pentru {produs.Denumire} ({produs.Cantitate.GetUnit()}): ");
                int cantitateIntrodusa = int.Parse(Console.ReadLine());

                // Crearea unui nou produs cu cantitatea actualizată și adăugarea acestuia la lista comenzii
                Produs produsCuCantitateActualizata = produs.WithCantitate(new Cantitate.CantitateUnitati(cantitateIntrodusa));
                comandaClient.Add(produsCuCantitateActualizata);
            }

            

            Console.WriteLine("Final de program!");
        }
    }
}
