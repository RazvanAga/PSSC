namespace PSSC_S3
{
    public record Produs(Pret.IPret Pret, string Cod, string Denumire)
    {
        public Produs WithCantitate(Pret.IPret pret) => this with { Pret = pret };
    }

}