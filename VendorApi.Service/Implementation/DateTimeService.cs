using System;
using VendorApi.Service.Contract;

namespace VendorApi.Service.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}