using System.Threading.Tasks;

namespace ReefCode.Reefi
{
    public interface IDisplayCommand
    {
        public void ClearDisplayText();

        public Task ClearDisplayTextAsync();

        public void SetDisplayText(string value);

        public Task SetDisplayTextAsync(string value);

        public void SetDisplayText(int line, string value);

        public Task SetDisplayTextAsync(int line, string value);
    }
}
