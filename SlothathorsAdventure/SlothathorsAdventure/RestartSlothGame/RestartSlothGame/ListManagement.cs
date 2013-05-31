using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    /// <summary>
    /// Clears All Lists, and Adds Elements to Lists
    /// </summary>
    class ListManagement
    {
        /// <summary>
        /// Clears all lists
        /// </summary>
        /// <param name="leafList">list of leaves</param>
        /// <param name="flowerList">list of flowers</param>
        /// <param name="rockList">list of rocks</param>
        /// <param name="jaguarList">list of jaguars</param>
        public void ListClear(List<Leaf> leafList, List<Flower> flowerList, List<Rock> rockList, List<Jaguar> jaguarList)
        {
            leafList.Clear();
            flowerList.Clear();
            rockList.Clear();
            jaguarList.Clear();
        }
        /// <summary>
        /// Adds elements to list
        /// </summary>
        /// <param name="leafList">list of leaves</param>
        /// <param name="viewPortRect">size of the screen</param>
        /// <param name="rand">random number to determine pickup location</param>
        /// <param name="spriteDict">value to access the dictonary of sprites where leaf is located</param>
        /// <param name="roomClass">room class</param>
        public void LeafPopulate(List<Leaf> leafList, Rectangle viewPortRect, Random rand, Dictionary<string, Texture2D> spriteDict, Room roomClass)
        {
            for (int leavesToAdd = 0; leavesToAdd < roomClass.LeafNumber; leavesToAdd++)
                leafList.Add(new Leaf(spriteDict["leaf"], (int)rand.Next(viewPortRect.Width - spriteDict["leaf"].Width),
                    (int)rand.Next(viewPortRect.Height - spriteDict["leaf"].Height)));
        }

        /// <summary>
        /// Adds elements to list
        /// </summary>
        /// <param name="leafList">list of flowers</param>
        /// <param name="viewPortRect">size of the screen</param>
        /// <param name="rand">random number to determine pickup location</param>
        /// <param name="spriteDict">value to access the dictonary of sprites where flower is located</param>
        /// <param name="roomClass">room class</param>
        public void FlowerPopulate(List<Flower> flowerList, Rectangle viewPortRect, Random rand, Dictionary<string, Texture2D> spriteDict, Room roomClass)
        {
            for (int flowersToAdd = 0; flowersToAdd < roomClass.FlowerNumber; flowersToAdd++)
                flowerList.Add(new Flower(spriteDict["flower"], (int)rand.Next(viewPortRect.Width - spriteDict["flower"].Width),
                    (int)rand.Next(viewPortRect.Height - spriteDict["flower"].Height)));
        }

        /// <summary>
        /// Adds elements to list
        /// </summary>
        /// <param name="leafList">list of rocks</param>
        /// <param name="viewPortRect">size of the screen</param>
        /// <param name="rand">random number to determine pickup location</param>
        /// <param name="spriteDict">value to access the dictonary of sprites where rock is located</param>
        /// <param name="roomClass">room class</param>
        public void RockPopulate(List<Rock> rockList, Rectangle viewPortRect, Random rand, Dictionary<string, Texture2D> spriteDict, Room roomClass)
        {
            for (int rocksToAdd = 0; rocksToAdd < roomClass.RockNumber; rocksToAdd++)
                rockList.Add(new Rock(spriteDict["sharpeningRock"], (int)rand.Next(viewPortRect.Width - spriteDict["sharpeningRock"].Width),
                    (int)rand.Next(viewPortRect.Height - spriteDict["sharpeningRock"].Height)));
        }

        /// <summary>
        /// Adds elements to list
        /// </summary>
        /// <param name="leafList">list of jaguars</param>
        /// <param name="viewPortRect">size of the screen</param>
        /// <param name="rand">random number to determine pickup location</param>
        /// <param name="spriteDict">value to access the dictonary of sprites where jaguar is located</param>
        /// <param name="roomClass">room class</param>
        public void JaguarPopulate(List<Jaguar> jaguarList, Rectangle viewPortRect, Random rand, Dictionary<string, Texture2D> spriteDict, Room roomClass)
        {
            for (int jaguarsToAdd = 0; jaguarsToAdd < roomClass.JaguarNumber; jaguarsToAdd++)
                jaguarList.Add(new Jaguar(spriteDict["jaguar"], (int)rand.Next(viewPortRect.Width - spriteDict["jaguar"].Width),
                    (int)rand.Next(viewPortRect.Height - spriteDict["jaguar"].Height)));
        }

        /// <summary>
        /// Calls the ClearList method and Adds elements to the list
        /// </summary>
        /// <param name="leafList">lsit of leaves</param>
        /// <param name="flowerList">list of flowers</param>
        /// <param name="rockList">list of rocks</param>
        /// <param name="jaguarList">list of jaguars</param>
        /// <param name="viewPortRect">rectangle the size of the screen</param>
        /// <param name="rand">random integer passed in to determine sprite placement</param>
        /// <param name="spriteDict">key to pass in to access the sprite image</param>
        /// <param name="roomClass">room class</param>
        public void ClearAndPopulate(List<Leaf> leafList, List<Flower> flowerList, List<Rock> rockList, List<Jaguar> jaguarList, Rectangle viewPortRect, Random rand, Dictionary<string, Texture2D> spriteDict, Room roomClass)
        {
            ListClear(leafList,flowerList,rockList,jaguarList);
            LeafPopulate(leafList, viewPortRect, rand, spriteDict, roomClass);
            FlowerPopulate(flowerList, viewPortRect, rand, spriteDict, roomClass);
            RockPopulate(rockList, viewPortRect, rand, spriteDict, roomClass);
            JaguarPopulate(jaguarList, viewPortRect, rand, spriteDict, roomClass);
        }
    }
}
