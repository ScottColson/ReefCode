namespace ReefCode.Reefi
{
    public interface ILight : ILightCommand, IDisplayCommand
    {
        public string IPAddress { get; }
        public string CustomName { get; }
        public string MAC { get; }
        public string ManufacturerName { get; }
    }
}
