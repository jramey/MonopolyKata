using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonopolyKata
{
    public class Board
    {
        private Banker banker;
        private Dice dice;
        private List<Space> spaces;
        private List<Property> properties;
        private List<Property> purple;
        private List<Property> lightBlue;
        private List<Property> violet;
        private List<Property> orange;
        private List<Property> red;
        private List<Property> yellow;
        private List<Property> green;
        private List<Property> blue;
        private List<Property> railroads;
        private List<Utility> utilities;
        private List<Property> realestate;
        private IEnumerable<Space> allSpaces;

        public Board(Banker banker, Dice dice)
        {
            this.banker = banker;
            this.dice = dice;
            spaces = new List<Space>();
            properties = new List<Property>();
            purple = new List<Property>();
            lightBlue = new List<Property>();
            violet = new List<Property>();
            orange = new List<Property>();
            red = new List<Property>();
            yellow = new List<Property>();
            green = new List<Property>();
            blue = new List<Property>();
            allSpaces = new List<Space>();
            realestate = new List<Property>();

            railroads = new List<Property>();
            utilities = new List<Utility>();
            BuildBoard();
        }

        private void BuildBoard()
        {
            spaces.Add(new Go("Go", 0, banker));
            purple.Add(new Property("Mediterranean Ave.", 1, 100, 12, purple, banker));
            spaces.Add(new Space(" Community Chest", 2, banker));
            purple.Add(new Property(" Baltic Ave.", 3, 100, 12, purple, banker));
            spaces.Add(new IncomeTax("Income Tax", 4, banker));
            railroads.Add(new Railroad("Reading Railroad", 5, 100, 12, railroads, banker));
            lightBlue.Add(new Property("Oriental Ave.", 6, 100, 12, lightBlue, banker));
            spaces.Add(new Space("Chance", 7, banker));
            lightBlue.Add(new Property("Vermont Ave.", 8, 100, 12, properties, banker));
            lightBlue.Add(new Property("Connecticut Ave.", 9, 100, 12, lightBlue, banker));
            spaces.Add(new Space("Just Visiting/Jail", 10, banker));
            violet.Add(new Property(" St. Charles Place", 11, 100, 12, violet, banker));
            utilities.Add(new Utility("Electric Company", 12, 150, utilities, banker, dice));
            violet.Add(new Property("States Ave", 13, 100, 12, violet, banker));
            violet.Add(new Property("Virginia Ave.", 14, 100, 12, violet, banker));
            railroads.Add(new Railroad("Pennsylvania RR", 15, 100, 12, railroads, banker));
            orange.Add(new Property("St. James Place", 16, 100, 12, orange, banker));
            spaces.Add(new Space("Community Chest", 17, banker));
            orange.Add(new Property("Tennessee Ave.", 18, 100, 12, orange, banker));
            orange.Add(new Property("New York Ave.", 19, 100, 12, orange, banker));
            spaces.Add(new Space("Free Parking", 20, banker));
            red.Add(new Property("Kentucky Ave.", 21, 100, 12, red, banker));
            spaces.Add(new Space("Chance", 22, banker));
            red.Add(new Property("Indiana Ave.", 23, 100, 12, red, banker));
            red.Add(new Property("Illinois Ave.", 24, 100, 12, red, banker));
            railroads.Add(new Railroad("B. & O. RR)", 25, 100, 12, railroads, banker));
            yellow.Add(new Property("Atlantic Ave.", 26, 100, 12, yellow, banker));
            yellow.Add(new Property("Ventnor Ave.", 27, 100, 12, yellow, banker));
            utilities.Add(new Utility("Water Works", 28, 150, utilities, banker, dice));
            yellow.Add(new Property("Marvin Gardens", 29, 100, 12, yellow, banker));     
            spaces.Add(new GoToJail("Go To Jail", 30, banker));
            green.Add(new Property("Pacific Ave.", 31, 100, 12, green, banker));
            green.Add(new Property("North Carolina Ave.", 32, 100, 12, green, banker));
            spaces.Add(new Space("Community Chest", 33, banker));
            green.Add(new Property("Pennsylvania Ave.", 34, 100, 12, green, banker));
            railroads.Add(new Railroad("Shortline RR", 35, 100, 12, railroads, banker));
            spaces.Add(new Space("Chance", 36, banker));
            blue.Add(new Property(" Park Place", 37, 100, 12, blue, banker));
            spaces.Add(new LuxuryTax("Luxuray Tax", 38, banker));
            blue.Add(new Property("Boardwalk", 39, 100, 12, blue, banker));

            allSpaces = spaces.Union(properties).Union(railroads).Union(utilities).Union(purple).Union(lightBlue).Union(violet).
                Union(orange).Union(red).Union(yellow).Union(green).Union(blue).OrderBy((b => b.Location));
        }

        public Space GetSpaceAtLocation(Int32 location)
        {
            return allSpaces.ElementAt(location);
        }
    }
}