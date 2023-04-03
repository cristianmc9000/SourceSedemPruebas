using System;

namespace Aplicacion.Interfaces
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}
