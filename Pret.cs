using CSharp.Choices;

namespace PSSC_S3
{
    [AsChoice]
    public static partial class Pret
    {
        public interface IPret
        {
            string GetUnit();
        }

        public record PretProdus(int Pret) : IPret
        {
            public string GetUnit() => "lei";
        }

    }
}
