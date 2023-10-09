using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ReefCode.Reefi
{
    public class Light : ILight
    {
        private readonly HttpClient httpClient;

        public string IPAddress { get; }
        public string CustomName { get; }
        public string MAC { get; }
        public string ManufacturerName { get;}

        public Light(string lightSettings)
        {
            // Sample light setting from group info
            // ReeFi_Uno-93DD2;ReeFi_Uno-51;C4:4F:33:69:3D:D1;192.168.4.51

            var settingParts = lightSettings.Split(';');

            ManufacturerName = settingParts[0];
            CustomName = settingParts[1];
            MAC = settingParts[2];
            IPAddress = settingParts[3];

            httpClient = new HttpClient
            {
                BaseAddress = new Uri($"http://{IPAddress}")
            };
        }

        public void Resume()
        {
            httpClient.GetAsync("resume.txt").Wait();
        }

        public async Task ResumeAsync()
        {
            await httpClient.GetAsync("resume.txt");
        }

        public void Set(IProfile profile)
        {
            Set(profile, 100m);
        }

        public void Set(IProfile profile, decimal level)
        {
            var request = BuildRequestString(profile, level);
            httpClient.GetAsync(request).Wait();
        }

        public async Task SetAsync(IProfile profile)
        {
            await SetAsync(profile, 100m);
        }

        public async Task SetAsync(IProfile profile, decimal level)
        {
            var request = BuildRequestString(profile, level);
            await httpClient.GetAsync(request);
        }

        private string BuildRequestString(IProfile profile, decimal level)
        {
            _ = profile ?? throw new ArgumentNullException(nameof(profile));

            if (level < 0) level = 0;
            else if (level > 100) level = 100;

            int ch0 = level == 0 ? 0 : (int)(profile.Channel_0 * 100m / level);
            int ch1 = level == 0 ? 0 : (int)(profile.Channel_1 * 100m / level);
            int ch2 = level == 0 ? 0 : (int)(profile.Channel_2 * 100m / level);
            int ch3 = level == 0 ? 0 : (int)(profile.Channel_3 * 100m / level);
            int ch4 = level == 0 ? 0 : (int)(profile.Channel_4 * 100m / level);
            int ch5 = level == 0 ? 0 : (int)(profile.Channel_5 * 100m / level);
            int ch6 = level == 0 ? 0 : (int)(profile.Channel_6 * 100m / level);
            int ch7 = level == 0 ? 0 : (int)(profile.Channel_7 * 100m / level);
            int ch8 = level == 0 ? 0 : (int)(profile.Channel_8 * 100m / level);

            return $"Lrequests?nowch0={ch0}&nowch1={ch1}&nowch2={ch2}&nowch3={ch3}&nowch4={ch4}&nowch5={ch5}&nowch6={ch6}&nowch7={ch7}&nowch8={ch8}";
        }

        public void ClearDisplayText()
        {
            var request = "CustomDisplay?clear=true";
            httpClient.GetAsync(request).Wait();
        }

        public async Task ClearDisplayTextAsync()
        {
            var request = "CustomDisplay?clear=true";
            await httpClient.GetAsync(request);
        }

        public void SetDisplayText(string value)
        {
            var textLines = value.Split(Environment.NewLine);
            var numLines = textLines.Length;
            if (numLines > 5) numLines = 5;

            for (int i = 0; i < numLines; i++)
            {
                SetDisplayText(i + 1, textLines[i]);
            }
        }

        public async Task SetDisplayTextAsync(string value)
        {
            var textLines = value.Split(Environment.NewLine);
            var numLines = textLines.Length;
            if (numLines > 5) numLines = 5;

            for (int i = 0; i < numLines; i++)
            {
                await SetDisplayTextAsync(i + 1, textLines[i]);
            }
        }

        public void SetDisplayText(int line, string value)
        {
            var request = $"CustomDisplay?clear=false&line={line}&txt={EncodeDisplayText(value)}";
            httpClient.GetAsync(request).Wait();
        }

        public async Task SetDisplayTextAsync(int line, string value)
        {
            var request = $"CustomDisplay?clear=false&line={line}&txt={EncodeDisplayText(value)}";
            await httpClient.GetAsync(request);
        }

        private string EncodeDisplayText(string value)
        {
            if (value == null) value = string.Empty;
            if (value.Length > 25) value = value.Substring(0, 25);
            return HttpUtility.UrlEncode($" {value}");
        }
    }
}
