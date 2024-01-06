using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace DPWEntityLibrary.Common
{
    public class Procedurefiguration : IConfiguration
    {
        public readonly IConfiguration _configuration;

        public Procedurefiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string this[string key]
        {
            get => _configuration[key];
            set => _configuration[key] = value;
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return _configuration.GetChildren();
        }

        public IChangeToken GetReloadToken()
        {
            return _configuration.GetReloadToken();
        }

        public IConfigurationSection GetSection(string key)
        {
            return _configuration.GetSection(key);
        }
    }
}

