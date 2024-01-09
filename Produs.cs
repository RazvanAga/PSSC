namespace PSSC_S3
{
    public record Produs(Cantitate.ICantitate Cantitate, string Cod, string Denumire, int Pret)
    {
        public Produs WithCantitate(Cantitate.ICantitate cantitate) => this with { Cantitate = cantitate };
        public Produs WithPret(int pret) => this with { Pret = pret };
    }

}