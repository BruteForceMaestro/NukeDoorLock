using Exiled.API.Interfaces;

namespace NukeDoorLock
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}
