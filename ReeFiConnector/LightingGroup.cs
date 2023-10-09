using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReefCode.Reefi
{
    public class LightingGroup : List<ILight>, ILightingGroup
    {
        public int GroupId { get; }

        public LightingGroup(string groupSetting)
        {
            var settingParts = groupSetting.Split('|');
            GroupId = int.Parse(settingParts[0]);

            for (int i=1; i<settingParts.Length; i++)
            {
                var light = new Light(settingParts[i]);
                Add(light);
            }
        }

        public void Resume()
        {
            foreach(var light in this)
            {
                light.Resume();
            }
        }

        public async Task ResumeAsync()
        {
            foreach (var light in this)
            {
                await light.ResumeAsync();
            }
        }

        public void Set(IProfile profile)
        {
            Set(profile, 100m);
        }

        public void Set(IProfile profile, decimal level)
        {
            foreach (var light in this)
            {
                light.Set(profile, level);
            }
        }

        public async Task SetAsync(IProfile profile)
        {
            await SetAsync(profile, 100m);
        }

        public async Task SetAsync(IProfile profile, decimal level)
        {
            foreach (var light in this)
            {
                await light.SetAsync(profile, level);
            }
        }

        public void ClearDisplayText()
        {
            foreach (var light in this)
            {
                light.ClearDisplayText();
            }
        }

        public async Task ClearDisplayTextAsync()
        {
            foreach (var light in this)
            {
                await light.ClearDisplayTextAsync();
            }
        }

        public void SetDisplayText(string value)
        {
            foreach (var light in this)
            {
                light.SetDisplayText(value);
            }
        }

        public async Task SetDisplayTextAsync(string value)
        {
            foreach (var light in this)
            {
                await light.SetDisplayTextAsync(value);
            }
        }

        public void SetDisplayText(int line, string value)
        {
            foreach (var light in this)
            {
                light.SetDisplayText(line, value);
            }
        }

        public async Task SetDisplayTextAsync(int line, string value)
        {
            foreach (var light in this)
            {
                await light.SetDisplayTextAsync(line, value);
            }
        }
    }
}
