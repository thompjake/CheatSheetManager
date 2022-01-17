using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using DraftTool.Models;

namespace DraftTool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string[] lines = System.IO.File.ReadAllLines(HttpContext.Server.MapPath("~/Bin/Content/FantasyPros_2017_Overall_ADP_Rankings.csv")).Skip(1).ToArray();
            List<Player> players = new List<Player>();
            foreach(string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                    players.Add(FromCsv(line));
            }
            DraftBoardViewModel viewModel = new DraftBoardViewModel();
            viewModel.Players = players;
            viewModel.RosterSize = 16;
            viewModel.Teams = 10;
            return View(viewModel);
        }

        public Player FromCsv(string csvLine)
        { // "Rank","Player","Team","Bye","POS","Yahoo","CBS","FFC","NFL","Fantrax","DW","AVG"
            string[] values = csvLine.Split(',');
            Player player = new Player();
            player.Name= values[1];
            player.TeamName = values[2];
            int byeWeek;
            int.TryParse(values[3],out byeWeek);
            player.ByeWeek = byeWeek;
            player.Position= Regex.Replace(values[4], @"[\d-]", string.Empty);
            return player;
        }

    }
}