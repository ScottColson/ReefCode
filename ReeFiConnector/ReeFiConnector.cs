using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace ReefCode.Reefi
{
    public class ReeFiConnector
    {
        private string IPAddress { get; }
        public IReadOnlyList<IProfile> Profiles { get; private set; } = new List<IProfile>();
        public ILightingGroupList Groups { get; private set; } = new LightingGroupList();
        public IReadOnlyList<ILight> Lights { get; private set; } = new List<ILight>();

        public ReeFiConnector(string address)
        {
            IPAddress = address;
            Refresh();
        }

        public void Refresh()
        {            
            using HttpClient httpClient = new HttpClient
            {
                BaseAddress = new Uri($"http://{IPAddress}")
            };

            LoadProfiles(httpClient);
            LoadGroups(httpClient);
            RefreshLightList();
        }

        private void LoadProfiles(HttpClient httpClient)
        {
            string profileInfo = FetchProfileInfo(httpClient);
            Profiles = ParseProfileInfo(profileInfo);
        }

        private string FetchProfileInfo(HttpClient httpClient)
        {
            using HttpResponseMessage response = httpClient.GetAsync("profiles.cfg").Result;
            {
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        private List<IProfile> ParseProfileInfo(string profileInfo)
        {
            var newProfileList = new List<IProfile>();
            var settings = new List<ProfileSetting>();

            foreach(var settingString in profileInfo.Split(','))
            {
                var setting = new ProfileSetting(settingString);
                settings.Add(setting);
            }

            var profileIds = settings.GroupBy(s => s.ProfileId).Select(a => a.Key);

            foreach(var profileId in profileIds)
            {
                var x = settings.Where(s => s.ProfileId == profileId)?.Select(s => new { s.Key, s.Value });
                var profileSettings = settings.Where(s => s.ProfileId == profileId && s.Key != null)?.Select(s => new { s.Key, s.Value })?.ToDictionary(s => s.Key, s => s.Value);
                var profile = new Profile(profileSettings);
                newProfileList.Add(profile);
            }

            return newProfileList;
        }
        
        private void LoadGroups(HttpClient httpClient)
        {
            string groupInfo = FetchGroupInfo(httpClient);
            Groups = ParseGroupInfo(groupInfo);
        }

        private string FetchGroupInfo(HttpClient httpClient)
        {
            using HttpResponseMessage response = httpClient.GetAsync("gleds.txt").Result;
            {
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        private ILightingGroupList ParseGroupInfo(string groupInfo)
        {
            var newLightGroupList = new LightingGroupList();

            var groupSettings = groupInfo.Split('\n');
            foreach(var setting in groupSettings)
            {
                newLightGroupList.Add(new LightingGroup(setting));
            }

            return newLightGroupList;
        }

        private void RefreshLightList()
        {
            var newList = new List<ILight>();

            foreach(var group in Groups)
            {
                foreach(var light in group)
                {
                    newList.Add(light);
                }
            }

            Lights = newList;
        }


        
    }
}
