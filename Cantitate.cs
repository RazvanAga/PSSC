using CSharp.Choices;

namespace PSSC_S3
{
    [AsChoice]
    public static partial class Cantitate
    {
        public interface ICantitate
        {
            string GetUnit();
        }

        public record CantitateUnitati(int Cantitate) : ICantitate
        {
            public string GetUnit() => "unitati";
        }

        public record CantitateKg(int Cantitate) : ICantitate
        {
            public string GetUnit() => "kg";
        }
    }
}
