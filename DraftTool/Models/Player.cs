using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraftTool.Models
{
    public class Player
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string TeamName { get; set; }
        public int ByeWeek { get; set; }
        public bool Drafted { get; set; }
    }
}