using System;
using System.Collections.Generic;
using System.Text;

namespace iptv_playlist_editor
{
    public class Title
    {
        public string RawTitle { get; set; }
        public string InnerTitle { get; set; }

        internal Title(string title, string innerTitle)
        {
            RawTitle = title;
            InnerTitle = innerTitle;
        }
    }
}