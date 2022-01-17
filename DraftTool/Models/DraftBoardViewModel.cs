using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DraftTool.Models
{
    public class DraftBoardViewModel
    {
        public List<Player> Players { get; set; }
        public int Teams { get; set; }
        public int RosterSize { get; set; }
    }
}