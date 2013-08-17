using System;

namespace X.DynamicData.Core
{
    public class Link
    {
        public String Url { get; set; }
        public String Icon { get; set; }
        public String Title { get; set; }

        public Link(string url, string icon, string title)
        {
            Url = url;
            Icon = icon;
            Title = title;
        }
    }
}
