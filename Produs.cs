namespace PSSC_S3
{
    public record Produs(Cantitate.ICantitate Cantitate, string Cod, string Denumire)
    {
        public Produs WithCantitate(Cantitate.ICantitate cantitate) => this with { Cantitate = cantitate };
    }

}