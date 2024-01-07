using System;
using System.Collections.Generic;
using static PSSC_S3.StareCos;
using static PSSC_S3.Cantitate;

namespace PSSC_S3
{

    public class Program{
        static void Main(string[] args)
        {
            Produs produs1 = new Produs(new Cantitate.CantitateKg(1), "cod1", "adresa");
            Produs produs2 = new Produs(new Cantitate.CantitateUnitati(39), "cod2", "adresa1");
            Produs produs3 = new Produs(new Cantitate.CantitateKg(1), "cod3", "adresa2");
            Client client1 = new Client("Iulian", "Birladeanu", "1234");
            List<Produs> Produse=new List<Produs>();
            Produse.Add(produs1);
            Produse.Add(produs2);


            PublicareComandaCommand command = new (client1, Produse);
            PublicareComandaWorkflow workflow = new PublicareComandaWorkflow();

            var result = workflow.Execute(command, (var)=> true);

            result.Match(
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

            Console.WriteLine("Final de program!");
   

        }
    }
}