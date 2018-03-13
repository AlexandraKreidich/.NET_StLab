using AutoMapper;
using System;

namespace WebApi.Services
{
    public class StringToDateTimeConverter : ITypeConverter<string, DateTimeOffset>
    {
        public DateTimeOffset Convert(string source, DateTimeOffset destination, ResolutionContext context)
        {
            DateTimeOffset.TryParse(source, out DateTimeOffset dateTimeOffset);

            return dateTimeOffset;
        }
    }
}
