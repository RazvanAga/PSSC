using System;
using System.Collections.Generic;
using static PSSC_S3.StareCos;
using static PSSC_S3.Pret;

namespace PSSC_S3
{
    public class Program
    {
        static void Main(string[] args)
        {
            

            Produs produs1 = new Produs(new Pret.PretProdus(2), "p41n3", "paine");
            Produs produs2 = new Produs(new Pret.PretProdus(4), "l4873", "lapte");
            Produs produs3 = new Produs(new Pret.PretProdus(8), "0u4", "oua");
            Client client1 = new Client("Razvan ", "Aga        ", "0753012509");
            Client client2 = new Client("Andrei ", "Aungurencei", "0787311885");
            Client client3 = new Client("Iasmina", "Iacob      ", "0768013858");

            // Adăugați clienții folosind GestiuneClienti
            GestiuneClienti gestiuneClienti = new GestiuneClienti();
            gestiuneClienti.AdaugaClient(client1);
            gestiuneClienti.AdaugaClient(client2);
            gestiuneClienti.AdaugaClient(client3);

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
                    Console.WriteLine("Meniu:");
                    Console.WriteLine("1. Adaugare client nou");
                    Console.WriteLine("2. Afisare toti clientii");
                    Console.WriteLine("3. Iesire din meniu");

                    int optiune;
                    do
                    {
                        Console.Write("Alege o optiune (1-3): ");
                        optiune = int.Parse(Console.ReadLine());

                        switch (optiune)
                        {
                            case 1:
                                // Adaugare client nou
                                Console.Write("Introduceti numele clientului: ");
                                string nume = Console.ReadLine();
                                Console.Write("Introduceti prenumele clientului: ");
                                string prenume = Console.ReadLine();
                                Console.Write("Introduceti numarul de telefon al clientului: ");
                                string cod = Console.ReadLine();

                                Client clientNou = new Client(nume, prenume, cod);
                                gestiuneClienti.AdaugaClient(clientNou);
                                break;

                            case 2:
                                // Afisare toti clientii
                                Console.WriteLine("Lista clientilor:");
                                int index = 1;
                                foreach (var client in gestiuneClienti.ObtineClienti())
                                {
                                    Console.WriteLine($"{index}. {client.nume} {client.prenume} {client.telefon}");
                                    index++;
                                }
                                break;

                            case 3:
                                // Iesire din meniu
                                Console.WriteLine("Iesire din meniu.");
                                break;

                            default:
                                Console.WriteLine("Optiune invalida. Reincercati.");
                                break;
                        }

                    } while (optiune != 3);

                    return @event;
                }
            );

           
            Console.WriteLine("Final de program!");
        }
    }
}
