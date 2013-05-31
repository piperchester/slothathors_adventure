using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    class SpawnNet : GameObject
    {
        /// <summary>
        /// The initial number of seconds
        /// </summary>
        int beginTimer;
        /// <summary>
        /// whether or not the loop has iterated
        /// </summary>
        bool firstTimeThrough = true;
        /// <summary>
        /// Random object reference call
        /// </summary>
        Random rand = new Random();
        /// <summary>
        /// Push's a net onto the net stack
        /// </summary>
        /// <param name="gameTime">current time of the game</param>
        /// <param name="netCount">the total net count</param>
        /// <param name="netStack">the stack data structure</param>
        public void SpawnANet(GameTime gameTime, int netCount, Stack<Net> netStack, Dictionary<string,Texture2D> spriteDict)
        {
            if (firstTimeThrough)
            {
                firstTimeThrough = false;
                beginTimer = gameTime.TotalGameTime.Seconds;
            }

            if (netCount != 0 && gameTime.TotalGameTime.Seconds - beginTimer > 2)
            {
                firstTimeThrough = true;
                beginTimer = gameTime.TotalGameTime.Seconds;
                netStack.Push(new Net(spriteDict["zap"], 800, rand.Next(400)));
                netCount--;
            }
        }
        /// <summary>
        /// Pop's a net off the net stack
        /// </summary>
        /// <param name="gameTime">current time of the game</param>
        /// <param name="netCount">the total net count</param>
        /// <param name="netStack">the stack data structure</param>
        public void RemoveNet(Room roomClass, Stack<Net> netStack)
        {
            // every time the net reaches the left side of the screen, pop it off the stack
            foreach (Net net in netStack)
            {
                if (net.spritePosition.X <= 0)
                {
                    netStack.Pop();
                    roomClass.NetNumber++;
                }
            }
        }
        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>class name</returns>
        public override string ToString()
        {
            return ClassName;
        }
    }
}
