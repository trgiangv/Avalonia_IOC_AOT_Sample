using System;

namespace AvaloniaPureDIAot.Services;

public sealed class TimeService : ITimeService
{
    public string NowString() => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
}
