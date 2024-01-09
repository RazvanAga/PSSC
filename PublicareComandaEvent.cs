using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSSC_S3
{
    [AsChoice]
    public static partial class PublicareComandaEvent
    {
        public interface IPublicareComandaEvent { }

        public record ComandaPublicareSucceedEvent : IPublicareComandaEvent
        {
            public string Csv { get; }
            public DateTime PublishedDate { get; }

            internal ComandaPublicareSucceedEvent(string csv, DateTime publishedDate)
            {
                Csv = csv;
                PublishedDate = publishedDate;
            }
        }

        public record ComandaPublicareFailEvent : IPublicareComandaEvent
        {
            public string Reason { get; }

            internal ComandaPublicareFailEvent(string reason)
            {
                Reason = reason;
            }
        }

    }
}
