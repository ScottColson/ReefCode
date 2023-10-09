using System.Collections.Generic;

namespace ReefCode.Reefi
{
    public class Profile : IProfile
    {
        public string Name { get; set; }

        public int Channel_0 { get; set; }

        public int Channel_1 { get; set; }

        public int Channel_2 { get; set; }

        public int Channel_3 { get; set; }

        public int Channel_4 { get; set; }

        public int Channel_5 { get; set; }

        public int Channel_6 { get; set; }

        public int Channel_7 { get; set; }

        public int Channel_8 { get; set; }

        public Profile() { }
        public Profile(IDictionary<string, string> settings)
        {
            Name = settings["name"]?.Trim();
            Channel_0 = int.Parse(settings["ch0"]);
            Channel_1 = int.Parse(settings["ch1"]);
            Channel_2 = int.Parse(settings["ch2"]);
            Channel_3 = int.Parse(settings["ch3"]);
            Channel_4 = int.Parse(settings["ch4"]);
            Channel_5 = int.Parse(settings["ch5"]);
            Channel_6 = int.Parse(settings["ch6"]);
            Channel_7 = int.Parse(settings["ch7"]);
            Channel_8 = int.Parse(settings["ch8"]);
        }
    }
}
