using System;
using System.Collections.Generic;

namespace MonopolyKata
{
    public class BoardFactory
    {
        public Board Create(Banker banker, List<Player> players, IDice dice, PrisonGuard guard)
        {
            var board= new Board(players, guard);
            var spaces = CreateBoard(banker, board, dice, guard);

            board.SetBoard(spaces);

            return board;
        }

        private Dictionary<Int32, IBoardSpace> CreateBoard(Banker banker, Board board, IDice dice, PrisonGuard guard)
        {
            var purples = new List<Property>();
            var mediterranean = new Property("Mediterranean Avenue", 60, 2, banker, purples);
            var baltic = new Property("Baltic Avenue", 60, 4, banker, purples);
            purples.AddRange(new[] { mediterranean, baltic });   

            var lightBlues = new List<Property>();
            var oriental = new Property("Oriental Avenue", 100, 6, banker, lightBlues);
            var vermont = new Property("Vermont Avenue", 100, 6, banker, lightBlues);
            var connecticut = new Property("Connecticut Avenue", 120, 8, banker, lightBlues);
            lightBlues.AddRange(new[] { oriental, vermont, connecticut });
            
            var violets = new List<Property>();
            var stCharlesPlace = new Property("St. Charles Place", 140, 10, banker, violets);
            var states = new Property("States Avenue", 140, 10, banker, violets);
            var virginia = new Property("Virginia Avenue", 160, 12, banker, violets);
            violets.AddRange(new[] { stCharlesPlace, states, virginia });

            var oranges = new List<Property>();
            var stJamesPlace = new Property("St. James Place", 180, 14, banker, oranges);
            var tennessee = new Property("Tennessee Avenue", 180, 14, banker, oranges);
            var newYork = new Property("New York Avenue", 200, 16, banker, oranges);
            oranges.AddRange(new[] { stJamesPlace, tennessee, newYork });
            
            var reds = new List<Property>();
            var kentucky = new Property("Kentucky Avenue", 220, 18, banker, reds);
            var indiana = new Property("Indiana Avenue", 220, 18, banker, reds);
            var illinois = new Property("Illinois Avenue", 240, 20, banker, reds);
            reds.AddRange(new[] { kentucky, indiana, illinois });

            var yellows = new List<Property>();
            var atlantic = new Property("Atlantic Avenue", 260, 22, banker, yellows);
            var ventor = new Property("Ventor Avenue", 260, 22, banker, yellows);
            var marvinGardens = new Property("Marvin Gardens", 280, 24, banker, yellows);
            yellows.AddRange(new[] { atlantic, ventor, marvinGardens });

            var greens = new List<Property>();
            var pacific = new Property("Pacific Avenue", 300, 26, banker, greens);
            var northCarolina = new Property("North Carolina Avenue", 300, 26, banker, greens);
            var pennsylvaniaAvenue = new Property("Pennsylvania Avenue", 320, 28, banker, greens);
            greens.AddRange(new[] { pacific, northCarolina, pennsylvaniaAvenue });
  
            var blues = new List<Property>();
            var parkPlace = new Property("Park Place", 350, 35, banker, blues);
            var boardwalk = new Property("Boardwalk", 400, 50, banker, blues);
            blues.AddRange(new[] { parkPlace, boardwalk });

            var railroads = new List<Railroad>();
            var readingRailroad = new Railroad("Reading Railroad", banker, railroads);
            var pennsylvaniaRailroad = new Railroad("Pennsylvania Railroad", banker, railroads);
            var bORailroad = new Railroad("B & O Railroad", banker, railroads);
            var shortLineRailroad = new Railroad("Short Line", banker, railroads);
            railroads.AddRange(new[] { readingRailroad, pennsylvaniaRailroad, bORailroad, shortLineRailroad });

            var utilities = new List<Utility>();
            var electric = new Utility("Electric Company", banker, dice, utilities);
            var water = new Utility("Water Works", banker, dice, utilities);
            utilities.AddRange(new[] { electric, water });

            var communityChestFactory = new CommunityChestFactory();
            var communityChest = communityChestFactory.Create(banker);

            var chanceFactory = new ChanceFactory();
            var chance = chanceFactory.Create(banker, board);

            var spaces = new Dictionary<Int32, IBoardSpace>
            {
                { 0, new Go(banker) },
                { 1, mediterranean },
                { 2, communityChest },
                { 3, baltic },
                { 4, new IncomeTax(banker) },
                { 5, readingRailroad },
                { 6, oriental },
                { 7, chance },
                { 8, vermont },
                { 9, connecticut }, 
                { 11, stCharlesPlace },
                { 12, electric },
                { 13, states },
                { 14, virginia },
                { 15, pennsylvaniaRailroad },
                { 16, stJamesPlace },
                { 17, communityChest },
                { 18, tennessee },
                { 19, newYork },
                { 21, kentucky },
                { 22, chance },
                { 23, indiana },
                { 24, illinois },
                { 25, bORailroad },
                { 26, atlantic },
                { 27, ventor },
                { 28, water },
                { 29, marvinGardens },
                { 30, new GoToJail(board, 10, guard) },
                { 31, pacific },
                { 32, northCarolina },
                { 33, communityChest },
                { 34, pennsylvaniaAvenue },
                { 35, shortLineRailroad },
                { 36, chance },
                { 37, parkPlace },
                { 38, new LuxuryTax(banker) },
                { 39, boardwalk }
            };

            return spaces;
        }
    }
}
