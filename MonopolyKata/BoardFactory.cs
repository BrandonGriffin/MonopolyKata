using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class BoardFactory
    {
        public Board Create(Banker teller, List<Player> players, IDice dice, PrisonGuard guard)
        {
            var positionKeeper = new Board(players, guard);
            var board = CreateBoard(teller, positionKeeper, dice, guard);

            positionKeeper.SetBoard(board);

            return positionKeeper;
        }

        private Dictionary<Int32, IBoardSpace> CreateBoard(Banker teller, Board positionKeeper, IDice dice, PrisonGuard guard)
        {
            var purples = new List<Property>();
            var mediterranean = new Property("Mediterranean Avenue", 60, 2, teller, purples);
            var baltic = new Property("Baltic Avenue", 60, 4, teller, purples);
            purples.AddRange(new[] { mediterranean, baltic });   

            var lightBlues = new List<Property>();
            var oriental = new Property("Oriental Avenue", 100, 6, teller, lightBlues);
            var vermont = new Property("Vermont Avenue", 100, 6, teller, lightBlues);
            var connecticut = new Property("Connecticut Avenue", 120, 8, teller, lightBlues);
            lightBlues.AddRange(new[] { oriental, vermont, connecticut });
            
            var violets = new List<Property>();
            var stCharlesPlace = new Property("St. Charles Place", 140, 10, teller, violets);
            var states = new Property("States Avenue", 140, 10, teller, violets);
            var virginia = new Property("Virginia Avenue", 160, 12, teller, violets);
            violets.AddRange(new[] { stCharlesPlace, states, virginia });

            var oranges = new List<Property>();
            var stJamesPlace = new Property("St. James Place", 180, 14, teller, oranges);
            var tennessee = new Property("Tennessee Avenue", 180, 14, teller, oranges);
            var newYork = new Property("New York Avenue", 200, 16, teller, oranges);
            oranges.AddRange(new[] { stJamesPlace, tennessee, newYork });
            
            var reds = new List<Property>();
            var kentucky = new Property("Kentucky Avenue", 220, 18, teller, reds);
            var indiana = new Property("Indiana Avenue", 220, 18, teller, reds);
            var illinois = new Property("Illinois Avenue", 240, 20, teller, reds);
            reds.AddRange(new[] { kentucky, indiana, illinois });

            var yellows = new List<Property>();
            var atlantic = new Property("Atlantic Avenue", 260, 22, teller, yellows);
            var ventor = new Property("Ventor Avenue", 260, 22, teller, yellows);
            var marvinGardens = new Property("Marvin Gardens", 280, 24, teller, yellows);
            yellows.AddRange(new[] { atlantic, ventor, marvinGardens });

            var greens = new List<Property>();
            var pacific = new Property("Pacific Avenue", 300, 26, teller, greens);
            var northCarolina = new Property("North Carolina Avenue", 300, 26, teller, greens);
            var pennsylvaniaAvenue = new Property("Pennsylvania Avenue", 320, 28, teller, greens);
            greens.AddRange(new[] { pacific, northCarolina, pennsylvaniaAvenue });
  
            var blues = new List<Property>();
            var parkPlace = new Property("Park Place", 350, 35, teller, blues);
            var boardwalk = new Property("Boardwalk", 400, 50, teller, blues);
            blues.AddRange(new[] { parkPlace, boardwalk });

            var railroads = new List<Railroad>();
            var readingRailroad = new Railroad("Reading Railroad", teller, railroads);
            var pennsylvaniaRailroad = new Railroad("Pennsylvania Railroad", teller, railroads);
            var bORailroad = new Railroad("B & O Railroad", teller, railroads);
            var shortLineRailroad = new Railroad("Short Line", teller, railroads);
            railroads.AddRange(new[] { readingRailroad, pennsylvaniaRailroad, bORailroad, shortLineRailroad });

            var utilities = new List<Utility>();
            var electric = new Utility("Electric Company", teller, dice, utilities);
            var water = new Utility("Water Works", teller, dice, utilities);
            utilities.AddRange(new[] { electric, water });

            var board = new Dictionary<Int32, IBoardSpace>
            {
                { 0, new Go(teller) },
                { 1, mediterranean },
                { 3, baltic },
                { 4, new IncomeTax(teller) },
                { 5, readingRailroad },
                { 6, oriental },
                { 8, vermont },
                { 9, connecticut }, 
                { 11, stCharlesPlace },
                { 12, electric },
                { 13, states },
                { 14, virginia },
                { 15, pennsylvaniaRailroad },
                { 16, stJamesPlace },
                { 18, tennessee },
                { 19, newYork },
                { 21, kentucky },
                { 23, indiana },
                { 24, illinois },
                { 25, bORailroad },
                { 26, atlantic },
                { 27, ventor },
                { 28, water },
                { 29, marvinGardens },
                { 30, new GoToJail(positionKeeper, 10, guard) },
                { 31, pacific },
                { 32, northCarolina },
                { 34, pennsylvaniaAvenue },
                { 35, shortLineRailroad },
                { 37, parkPlace },
                { 38, new LuxuryTax(teller) },
                { 39, boardwalk }
            };

            return board;
        }
    }
}
