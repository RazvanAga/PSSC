using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSC_S3
{
    [AsChoice]
    public static partial class StareCos
    {
        public interface IStarecos { }

    public record NevalidatStareCos:IStarecos
    {
        public NevalidatStareCos(Client client, List<Produs> produse)
        {
            Client = client;
            Produse = produse;

        }
        public Client Client; 
        public List<Produs> Produse; 
    }
    public record GolStareCos:IStarecos
    {
         public GolStareCos(Client client, List<Produs> produse)
        {
                Client = client;
                Produse = produse;

        }
        public Client Client;
        public List<Produs> Produse; 
    }
    public record ValidatStareCos:IStarecos
    {
        public ValidatStareCos(Client client, List<Produs> produse)
        {
            Client = client;
            Produse = produse;
        }
        public Client Client {get; }
        public List<Produs> Produse{get; }
        }
    // public record PlatitStareCos:IStarecos
    //     {
    //         PlatitStareCos(Client client, List<Produs> produse, DateTime TimpulPlata)
    //         {
    //             Client = client;
    //             Produse = produse;
    //         }
    //         public Client Client;
    //         public List<Produs> Produse; 
    //     }

     public record PublicatStareCos:IStarecos
    {
        public PublicatStareCos(Client client, List<Produs> produse, string csv, DateTime publishedDate)
        {
            Client = client;
            Produse = produse;
            PublishedDate = publishedDate;
            Csv = csv;
        }
        public Client Client {get; }
        public List<Produs> Produse{get; }

        public DateTime PublishedDate { get; }
            public string Csv { get; }
        }

      

     
    }
}
