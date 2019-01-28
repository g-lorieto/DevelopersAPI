using DevelopersApi.Core.Interfaces;

namespace DevelopersApi.Core.Settings
{
    public class AppSettingsModel
    {
        public string JSONFIle { get; set; }
        public string BaseAddress { get; set; }
        public string GetAllServiceEndpoint { get; set; }
    }
}