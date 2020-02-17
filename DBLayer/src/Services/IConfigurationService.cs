using Microsoft.Extensions.Configuration;

namespace DBLayer.Service{
    public interface IConfigurationService{
        public IConfiguration GetConfiguration();
    }
}