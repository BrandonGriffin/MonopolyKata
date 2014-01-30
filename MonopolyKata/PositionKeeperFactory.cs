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
            var utilities = new List<Property>();

            var mediterranean = new Property("Mediterranean Avenue", 60, 2, teller, purples);
            var baltic = new Property("Baltic Avenue", 60, 4, teller, purples);
            var readingRailroad = new Railroad("Reading Railroad", teller, railroads);
            var oriental = new Property("Oriental Avenue", 100, 6, teller, lightBlues);
            var vermont = new Property("Vermont Avenue", 100, 6, teller, lightBlues);
            var connecticut = new Property("Connecticut Avenue", 120, 8, teller, lightBlues);
            var stCharlesPlace = new Property("St. Charles Place", 140, 10, teller, violets);
            var electric = new Property("Electric Company", 150, 0, teller, utilities);
            var states = new Property("States Avenue", 140, 10, teller, violets);
            var virginia = new Property("Virginia Avenue", 160, 12, teller, violets);
            var pennsylvaniaRailroad = new Railroad("Pennsylvania Railroad", teller, railroads);
            var stJamesPlace = new Property("St. James Place", 180, 14, teller, oranges);
            var tennessee = new Property("Tennessee Avenue", 180, 14, teller, oranges);
            var newYork = new Property("New York Avenue", 200, 16, teller, oranges);
            var kentucky = new Property("Kentucky Avenue", 220, 18, teller, reds);
            var indiana = new Property("Indiana Avenue", 220, 18, teller, reds);
            var illinois = new Property("Illinois Avenue", 240, 20, teller, reds);

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
                { 24, illinios },
                { 25, new Railroad("B & O Railroad", teller, railroads) },
                { 26, new Property("Atlantic Avenue", 260, 22, teller, yellows) },
                { 27, new Property("Ventor Avenue", 260, 22, teller, yellows) },
                { 28, new Property("Water Works", 150, 0, teller, utilities) },
                { 29, new Property("Marvin Gardens", 280, 24, teller, yellows) },
                { 30, new GoToJail(positionKeeper, 10) },
                { 31, new Property("Pacific Avenue", 300, 26, teller, greens) },
                { 32, new Property("North Carolina Avenue", 300, 26, teller, greens) },
                { 34, new Property("Pennsylvania Avenue", 320, 28, teller, greens) },
                { 35, new Railroad("Short Line", teller, railroads) },
                { 37, new Property("Park Place", 350, 35, teller, blues) },
                { 38, new LuxuryTax(teller) },
                { 39, new Property("Boardwalk", 400, 50, teller, blues) },
            };

            purples.AddRange(new[] { mediterranean, baltic });
        }
    }
}
