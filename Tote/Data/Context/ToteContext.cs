using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data.Context
{
    class ToteContext
    {
        public List<Sport> Sports { get; set; }
        public List<Tournament> Tournaments { get; set; }
        public List<Command> Commands { get; set; }
        public List<Match> Matches { get; set; }
        public List<Tour> Tours { get; set; }
        public List<Rate> Rates { get; set; }

        public ToteContext()
        {
            Sports = new List<Sport>();
            Sports.Add(new Sport { SportId=1, Name="Football"});
            Sports.Add(new Sport { SportId = 2, Name = "Hockey" });
            Sports.Add(new Sport { SportId = 3, Name = "Basketball" });

            Commands = new List<Command>();
            Commands.Add(new Command {CommandId=1, Name="AC Milan", SporttId=1 });
            Commands.Add(new Command { CommandId = 2, Name = "Juventus", SporttId = 1 });
            Commands.Add(new Command { CommandId = 3, Name = "Napoli", SporttId = 1 });
            Commands.Add(new Command { CommandId = 4, Name = "Dinamo Minsk", SporttId = 2 });
            Commands.Add(new Command { CommandId = 5, Name = "AK Bars", SporttId = 2 });
            Commands.Add(new Command { CommandId = 6, Name = "Dinamo Riga", SporttId = 2 });
            Commands.Add(new Command { CommandId = 7, Name = "CSKA Moscow", SporttId = 3 });
            Commands.Add(new Command { CommandId = 8, Name = "Khimki", SporttId = 3 });
            Commands.Add(new Command { CommandId = 9, Name = "Bayern Munich", SporttId = 1 });
            Commands.Add(new Command { CommandId = 10, Name = "Real Madrid", SporttId = 1 });

            Tournaments = new List<Tournament>();
            Tournaments.Add(new Tournament {TournamentId=1, Name="Seria A", SportId=1 });
            Tournaments.Add(new Tournament { TournamentId = 2, Name = "Bundesliga", SportId = 1 });
            Tournaments.Add(new Tournament { TournamentId = 3, Name = "Spain Championship", SportId = 1 });
            Tournaments.Add(new Tournament { TournamentId = 4, Name = "Euroliga", SportId = 3 });
            Tournaments.Add(new Tournament { TournamentId = 5, Name = "KHL", SportId = 2 });
            Tournaments.Add(new Tournament { TournamentId = 6, Name = "Champions League", SportId = 1 });

            Tours = new List<Tour>();
            Tours.Add(new Tour {TourId=1, Name="The first tour" });
            Tours.Add(new Tour { TourId = 2, Name = "The second tour" });
            Tours.Add(new Tour { TourId = 3, Name = "The third tour" });
            Tours.Add(new Tour { TourId = 4, Name = "The quarter-final" });

            Matches = new List<Match>();
            Matches.Add(new Match { MatchId = 1, CommandIdHome = 1, CommandIdGuest = 2, TournamentId = 1, TourId = 1, Date = new DateTime(2017,09,17,21,45,0), Result="0:2" });
            Matches.Add(new Match { MatchId = 2, CommandIdHome = 3, CommandIdGuest = 2, TournamentId = 1, TourId = 2, Date = new DateTime(2017, 10, 12, 21, 45, 0), Result = "3:2" });
            Matches.Add(new Match { MatchId = 3, CommandIdHome = 3, CommandIdGuest = 1, TournamentId = 1, TourId = 3, Date = new DateTime(2017, 11, 19, 22, 45, 0), Result = "" });
            Matches.Add(new Match { MatchId = 4, CommandIdHome = 4, CommandIdGuest = 6, TournamentId = 5, TourId = 1, Date = new DateTime(2017, 09, 17, 16, 0, 0), Result = "3:2" });
            Matches.Add(new Match { MatchId = 5, CommandIdHome = 5, CommandIdGuest = 4, TournamentId = 5, TourId = 3, Date = new DateTime(2017, 11, 21, 21, 0, 0), Result = "" });
            Matches.Add(new Match { MatchId = 6, CommandIdHome = 7, CommandIdGuest = 8, TournamentId = 4, TourId = 4, Date = new DateTime(2017, 12, 18, 21, 10, 0), Result = "102:88" });
            Matches.Add(new Match { MatchId = 7, CommandIdHome = 9, CommandIdGuest = 10, TournamentId = 6, TourId = 1, Date = new DateTime(2017, 09, 17, 21, 45, 0), Result = "2:2" });
            Matches.Add(new Match { MatchId = 8, CommandIdHome = 10, CommandIdGuest = 9, TournamentId = 6, TourId = 3, Date = new DateTime(2017, 11, 22, 21, 45, 0), Result = "3:1" });

            Rates = new List<Rate>();
            Rates.Add(new Rate { RateId = 1, MatchId = 1, WinCommandHome = 1.5, WinCommandGuest = 3.12, Draw = 2.26});
            Rates.Add(new Rate { RateId = 2, MatchId = 2, WinCommandHome = 2.89, WinCommandGuest = 1.72, Draw = 1.96 });
            Rates.Add(new Rate { RateId = 3, MatchId = 3, WinCommandHome = 1.32, WinCommandGuest = 2.46, Draw = 1.82 });
            Rates.Add(new Rate { RateId = 4, MatchId = 5, WinCommandHome = 4.6, WinCommandGuest = 1.35, Draw = 2.37 });
            Rates.Add(new Rate { RateId = 5, MatchId = 7, WinCommandHome = 1.57, WinCommandGuest = 2.12, Draw = 3.52 });
            Rates.Add(new Rate { RateId = 6, MatchId = 8, WinCommandHome = 1.34, WinCommandGuest = 2.68, Draw = 1.98 });

        }

    }
}
