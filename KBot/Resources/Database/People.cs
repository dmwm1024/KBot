using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace KBot.Resources.Database
{
    public class Person
    {
        [Key]
        public ulong Id { get; set; }
        public int BdayMonth { get; set; }
        public int BdayDay { get; set; }

        // Overwatch Stuff
        public string BattleTag { get; set; }
        public bool IsProfilePrivate { get; set; }
        public ushort CompetitiveRank { get; set; }

        // Stream Stuff
        public string Name { get; set; }        // The name of their stream (eg. kadeoverwatch)
        public bool IsLive { get; set; }        // Boolean conversation of stream_type = live
        public string Preview { get; set; }     // Get the preview.medium
        public string Title { get; set; }       // This is the channel.status
        public string DisplayName { get; set; } // channel.name
        public string Logo { get; set; }
        public string Banner { get; set; }
        public string Url { get; set; }
        public int Views { get; set; }
        public int Followers { get; set; }
    }
}
