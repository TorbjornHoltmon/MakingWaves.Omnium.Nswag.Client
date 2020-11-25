using System;
using Microsoft.Extensions.Configuration;

namespace Omnium.Nswag.Client
{
    public class OmniumClientBaseSettings : IOmniumClientBaseSettings
    {
        public IConfiguration Configuration { get; }
        public string? AccessToken { get; set; }
        public DateTimeOffset Expiration { get; set; }

        public OmniumClientBaseSettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}