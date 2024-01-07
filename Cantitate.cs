using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp.Choices;

namespace PSSC_S3{
    [AsChoice]
    public static partial class Cantitate{
        public interface ICantitate{};
        public record CantitateUnitati(int cant):ICantitate;
        public record CantitateKg(int kg):ICantitate;

    }


}