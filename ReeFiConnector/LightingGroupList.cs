using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReefCode.Reefi
{
    public class LightingGroupList : List<ILightingGroup>, ILightingGroupList
    {
        public void Resume()
        {
            foreach(var group in this)
            {
                group.Resume();
            }
        }

        public async Task ResumeAsync()
        {
            foreach (var group in this)
            {
                await group.ResumeAsync();
            }
        }

        public void Set(IProfile profile)
        {
            Set(profile, 100m);
        }

        public void Set(IProfile profile, decimal level)
        {
            foreach (var group in this)
            {
                group.Set(profile, level);
            }
        }

        public async Task SetAsync(IProfile profile)
        {
            await SetAsync(profile, 100m);
        }

        public async Task SetAsync(IProfile profile, decimal level)
        {
            foreach (var group in this)
            {
                await group.SetAsync(profile, level);
            }
        }

        public void ClearDisplayText()
        {
            foreach (var group in this)
            {
                group.ClearDisplayText();
            }
        }

        public async Task ClearDisplayTextAsync()
        {
            foreach (var group in this)
            {
                await group.ClearDisplayTextAsync();
            }
        }

        public void SetDisplayText(string value)
        {
            foreach (var group in this)
            {
                group.SetDisplayText(value);
            }
        }

        public async Task SetDisplayTextAsync(string value)
        {
            foreach (var group in this)
            {
                await group.SetDisplayTextAsync(value);
            }
        }

        public void SetDisplayText(int line, string value)
        {
            foreach (var group in this)
            {
                group.SetDisplayText(line, value);
            }
        }

        public async Task SetDisplayTextAsync(int line, string value)
        {
            foreach (var group in this)
            {
                await group.SetDisplayTextAsync(line, value);
            }
        }
    }
}
