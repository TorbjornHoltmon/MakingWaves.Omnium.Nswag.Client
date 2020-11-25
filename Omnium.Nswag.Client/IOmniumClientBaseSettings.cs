using System;
using Microsoft.Extensions.Configuration;

namespace Omnium.Nswag.Client
{
    public interface IOmniumClientBaseSettings
    {
        IConfiguration Configuration { get; }

        string? AccessToken { get; set; }

        DateTimeOffset Expiration { get; set; }
    }
}