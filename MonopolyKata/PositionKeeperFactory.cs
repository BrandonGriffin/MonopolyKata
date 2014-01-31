using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyKata
{
    public class PositionKeeperFactory
    {
        public PositionKeeper Create(Teller teller, List<Player> players)
        {
            var positionKeeper = new PositionKeeper(players);
            var board = CreateBoard(teller, positionKeeper);

            positionKeeper.SetBoard(board);

            return positionKeeper;
        }

        private Dictionary<Int32, IBoardSpace> CreateBoard(Teller teller, PositionKeeper positionKeeper)
        {
            var purples = new List<Property>();
            var lightBlues = new List<Property>();
            var violets = new List<Property>();
            var oranges = new List<Property>();
            var reds = new List<Property>();
            var yellows = new List<Property>();
            var greens = new List<Property>();
            var blues = new List<Property>();
            var railroads = new List<Railroad>();
            var utilities = new List<Utility>();

            var mediterranean = new Property("Mediterranean Avenue", 60, 2, teller, purples);
            var baltic = new Property("Baltic Avenue", 60, 4, teller, purples);
            var readingRailroad = new Railroad("Reading Railroad", teller, railroads);
            var oriental = new Property("Oriental Avenue", 100, 6, teller, lightBlues);
            var vermont = new Property("Vermont Avenue", 100, 6, teller, lightBlues);
            var connecticut = new Property("Connecticut Avenue", 120, 8, teller, lightBlues);
            var stCharlesPlace = new Property("St. Charles Place", 140, 10, teller, violets);
            var electric = new Utility("Electric Company", teller, utilities);
            var states = new Property("States Avenue", 140, 10, teller, violets);
            var virginia = new Property("Virginia Avenue", 160, 12, teller, violets);
            var pennsylvaniaRailroad = new Railroad("Pennsylvania Railroad", teller, railroads);
            var stJamesPlace = new Property("St. James Place", 180, 14, teller, oranges);
            var tennessee = new Property("Tennessee Avenue", 180, 14, teller, oranges);
            var newYork = new Property("New York Avenue", 200, 16, teller, oranges);
            var kentucky = new Property("Kentucky Avenue", 220, 18, teller, reds);
            var indiana = new Property("Indiana Avenue", 220, 18, teller, reds);
            var illinois = new Property("Illinois Avenue", 240, 20, teller, reds);
            var bORailroad = new Railroad("B & O Railroad", teller, railroads);
            var atlantic = new Property("Atlantic Avenue", 260, 22, teller, yellows);
            var ventor = new Property("Ventor Avenue", 260, 22, teller, yellows);
            var water = new Utility("Water Works", teller, utilities);
            var marvinGardens = new Property("Marvin Gardens", 280, 24, teller, yellows);
            var pacific = new Property("Pacific Avenue", 300, 26, teller, greens);
            var northCarolina = new Property("North Carolina Avenue", 300, 26, teller, greens);
            var pennsylvaniaAvenue = new Property("Pennsylvania Avenue", 320, 28, teller, greens);
            var shortLineRailroad = new Railroad("Short Line", teller, railroads);
            var parkPlace = new Property("Park Place", 350, 35, teller, blues);
            var boardwalk = new Property("Boardwalk", 400, 50, teller, blues);

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
                { 30, new GoToJail(positionKeeper, 10) },
                { 31, pacific },
                { 32, northCarolina },
                { 34, pennsylvaniaAvenue },
                { 35, shortLineRailroad },
                { 37, parkPlace },
                { 38, new LuxuryTax(teller) },
                { 39, boardwalk }
            };

            purples.AddRange(new[] { mediterranean, baltic });
            lightBlues.AddRange(new[] { oriental, vermont, connecticut });
            violets.AddRange(new[] { stCharlesPlace, states, virginia });
            oranges.AddRange(new[] { stJamesPlace, tennessee, newYork });
            reds.AddRange(new[] { kentucky, indiana, illinois });
            yellows.AddRange(new[] { atlantic, ventor, marvinGardens });
            greens.AddRange(new[] { pacific, northCarolina, pennsylvaniaAvenue });
            blues.AddRange(new[] { parkPlace, boardwalk });
            railroads.AddRange(new[] { readingRailroad, pennsylvaniaRailroad, bORailroad, shortLineRailroad });
            utilities.AddRange(new[] { electric, water });

            return board;
        }
    }
}
