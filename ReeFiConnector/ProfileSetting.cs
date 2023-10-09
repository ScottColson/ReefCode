namespace ReefCode.Reefi
{
    public class ProfileSetting
    {
        public int ProfileId { get; }
        public string Key { get; }
        public string Value { get; }

        public ProfileSetting(string settingString)
        {
            if (string.IsNullOrEmpty(settingString))
            {
                return;
            }

            var keyValueSplit = settingString.Split('=');
            var profileKeySplit = keyValueSplit[0].Split('_');

            ProfileId = int.Parse(profileKeySplit[0][1..]);
            Key = profileKeySplit[1];
            Value = keyValueSplit[1];
        }
    }
}
