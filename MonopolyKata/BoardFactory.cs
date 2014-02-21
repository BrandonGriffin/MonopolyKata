using System;
using System.Collections.Generic;
using MonopolyKata.Cards;
using MonopolyKata.RentStrategies;
using MonopolyKata.Spaces;

namespace MonopolyKata
{
    public class BoardFactory
    {
        public Board Create(Banker banker, IEnumerable<String> players, IDice dice, PrisonGuard guard)
        {
            var board = new Board(players);
            var spaces = CreateSpaces(banker, board, dice, guard);

            board.SetSpaces(spaces);

            return board;
        }

        private Dictionary<Int32, IBoardSpace> CreateSpaces(Banker banker, Board board, IDice dice, PrisonGuard guard)
        {
            var purples = new List<RealEstate>();
            var purpleRentStrategy = new PropertyRentStrategy(purples);
            var mediterranean = new RealEstate(banker, 60, 2, purpleRentStrategy);
            var baltic = new RealEstate(banker, 60, 4, purpleRentStrategy);
            purples.AddRange(new[] { mediterranean, baltic });   

            var lightBlues = new List<RealEstate>();
            var lightBlueRentStrategy = new PropertyRentStrategy(lightBlues);
            var oriental = new RealEstate(banker, 100, 6, lightBlueRentStrategy);
            var vermont = new RealEstate(banker, 100, 6, lightBlueRentStrategy);
            var connecticut = new RealEstate(banker, 120, 8, lightBlueRentStrategy);
            lightBlues.AddRange(new[] { oriental, vermont, connecticut });
            
            var violets = new List<RealEstate>();
            var violetRentStrategy = new PropertyRentStrategy(violets);
            var stCharlesPlace = new RealEstate(banker, 140, 10, violetRentStrategy);
            var states = new RealEstate(banker, 140, 10, violetRentStrategy);
            var virginia = new RealEstate(banker, 140, 12, violetRentStrategy);
            violets.AddRange(new[] { stCharlesPlace, states, virginia });

            var oranges = new List<RealEstate>();
            var orangeRentStrategy = new PropertyRentStrategy(oranges);
            var stJamesPlace = new RealEstate(banker, 180, 14, orangeRentStrategy);
            var tennessee = new RealEstate(banker, 180, 14, orangeRentStrategy);
            var newYork = new RealEstate(banker, 200, 16, orangeRentStrategy);
            oranges.AddRange(new[] { stJamesPlace, tennessee, newYork });
            
            var reds = new List<RealEstate>();
            var redRentStrategy = new PropertyRentStrategy(reds);
            var kentucky = new RealEstate(banker, 220, 18, redRentStrategy);
            var indiana = new RealEstate(banker, 220, 18, redRentStrategy);
            var illinois = new RealEstate(banker, 240, 20, redRentStrategy);
            reds.AddRange(new[] { kentucky, indiana, illinois });

            var yellows = new List<RealEstate>();
            var yellowRentStrategy = new PropertyRentStrategy(yellows);
            var atlantic = new RealEstate(banker, 260, 22, yellowRentStrategy);
            var ventor = new RealEstate(banker, 260, 22, yellowRentStrategy);
            var marvinGardens = new RealEstate(banker, 280, 24, yellowRentStrategy);
            yellows.AddRange(new[] { atlantic, ventor, marvinGardens });

            var greens = new List<RealEstate>();
            var greenRentStrategy = new PropertyRentStrategy(greens);
            var pacific = new RealEstate(banker, 300, 26, greenRentStrategy);
            var northCarolina = new RealEstate(banker, 300, 26, greenRentStrategy);
            var pennsylvaniaAvenue = new RealEstate(banker, 320, 28, greenRentStrategy);
            greens.AddRange(new[] { pacific, northCarolina, pennsylvaniaAvenue });
  
            var blues = new List<RealEstate>();
            var blueRentStrategy = new PropertyRentStrategy(blues);
            var parkPlace = new RealEstate(banker, 350, 35, blueRentStrategy);
            var boardwalk = new RealEstate(banker, 400, 50, blueRentStrategy);
            blues.AddRange(new[] { parkPlace, boardwalk });

            var railroads = new List<RealEstate>();
            var railroadRentStrategy = new RailroadRentStrategy(railroads);
            var readingRailroad = new RealEstate(banker, 200, 25, railroadRentStrategy);
            var pennsylvaniaRailroad = new RealEstate(banker, 200, 25, railroadRentStrategy);
            var bORailroad = new RealEstate(banker, 200, 25, railroadRentStrategy);
            var shortLineRailroad = new RealEstate(banker, 200, 25, railroadRentStrategy);
            railroads.AddRange(new[] { readingRailroad, pennsylvaniaRailroad, bORailroad, shortLineRailroad });

            var utilities = new List<RealEstate>();
            var utilityRentStrategy = new UtilityRentStrategy(utilities, dice);
            var electric = new RealEstate(banker, 150, 0, utilityRentStrategy);
            var water = new RealEstate(banker, 150, 0, utilityRentStrategy);
            utilities.AddRange(new[] { electric, water });

            var communityChestCards = CreateCommunityChestCards(banker, board, guard);
            var communityChest = new CardSpace(communityChestCards);

            var chanceCards = CreateChanceCards(banker, board, guard, utilityRentStrategy, railroadRentStrategy);
            var chance = new CardSpace(chanceCards);

            var spaces = new Dictionary<Int32, IBoardSpace>
            {
                { 0, new Go(banker) },
                { 1, mediterranean },
                { 2, communityChest },
                { 3, baltic },
                { 4, new IncomeTax(banker, 200, 10) },
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
                { 38, new LuxuryTax(banker, 75) },
                { 39, boardwalk }
            };

            return spaces;
        }
        
        private Queue<ICard> CreateCommunityChestCards(Banker banker, Board board, PrisonGuard guard)
        {
            var christmasFund = new Collect(banker, 100);
            var inheritance = new Collect(banker, 100);
            var soldStock = new Collect(banker, 45);
            var bankError = new Collect(banker, 200);
            var receiveForServices = new Collect(banker, 25);
            var beautyContestWinnings = new Collect(banker, 10);
            var taxRefund = new Collect(banker, 20);
            var lifeInsurance = new Collect(banker, 100);

            var hospitalBill = new Pay(banker, 100);
            var doctorsFee = new Pay(banker, 50);
            var schoolTax = new Pay(banker, 150);

            var grandOpera = new CollectFromEachPlayer(banker, 50);
            var goToJail = new AdvanceTo(board, 30);
            var advanceToGo = new AdvanceTo(board, 0);
            var getOutOfJailFree = new GetOutOfJailFree(guard);

            var cards = new Queue<ICard>();
            cards.Enqueue(christmasFund);
            cards.Enqueue(inheritance);
            cards.Enqueue(soldStock);
            cards.Enqueue(bankError);
            cards.Enqueue(receiveForServices);
            cards.Enqueue(beautyContestWinnings);
            cards.Enqueue(taxRefund);
            cards.Enqueue(lifeInsurance);
            cards.Enqueue(hospitalBill);
            cards.Enqueue(doctorsFee);
            cards.Enqueue(schoolTax);
            cards.Enqueue(grandOpera);
            cards.Enqueue(goToJail);
            cards.Enqueue(advanceToGo);
            cards.Enqueue(getOutOfJailFree);

            return cards;
        }

        private Queue<ICard> CreateChanceCards(Banker banker, Board board, PrisonGuard guard, UtilityRentStrategy utilityRentStrtegy, RailroadRentStrategy railroadRentStrategy)
        {
            var bankDividend = new Collect(banker, 50);
            var maturedLoan = new Collect(banker, 150);
            var poorTax = new Pay(banker, 15);

            var moveToBoardwalk = new Advance(board, banker, 39);
            var rideTheReading = new Advance(board, banker, 5);
            var moveToIllinois = new Advance(board, banker, 24);
            var moveToStCharles = new Advance(board, banker, 11);
            var moveToNearestRailroad = new AdvanceToNearest(board, new[] { 5, 15, 25, 35 }, railroadRentStrategy);
            var MoveToNearest = new AdvanceToNearest(board, new[] { 12, 28 }, utilityRentStrtegy);
            var goBack3Spaces = new GoBackSpaces(board, 3);

            var chairmanOfTheboard = new PayEachPlayer(banker, 50);
            var goToJail = new AdvanceTo(board, 30);
            var advanceToGo = new AdvanceTo(board, 0);
            var getOutofJailFree = new GetOutOfJailFree(guard);
            
            var cards = new Queue<ICard>();
            cards.Enqueue(bankDividend);
            cards.Enqueue(maturedLoan);
            cards.Enqueue(poorTax);
            cards.Enqueue(moveToNearestRailroad);
            cards.Enqueue(moveToBoardwalk);
            cards.Enqueue(chairmanOfTheboard);
            cards.Enqueue(moveToNearestRailroad);
            cards.Enqueue(rideTheReading);
            cards.Enqueue(moveToIllinois);
            cards.Enqueue(moveToStCharles);
            cards.Enqueue(goToJail);
            cards.Enqueue(advanceToGo);
            cards.Enqueue(getOutofJailFree);

            return cards;
        }
    }
}
