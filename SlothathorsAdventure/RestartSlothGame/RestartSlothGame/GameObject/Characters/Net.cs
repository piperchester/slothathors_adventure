using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    /// <summary>
    /// Net Class, inherits from Character amd the Draw and Update Interface
    /// </summary>
    sealed class Net : Character, IDraw_Update
    {
        /// <summary>
        /// Initializing a new Random object to call from
        /// </summary>
        Random rand = new Random();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="netSprite">Net Image</param>
        /// <param name="randomX">An X coordinate, randomly generated in the game class</param>
        /// <param name="randomY">An Y coordinate, randomly generated in the game class</param>
        public Net(Texture2D netSprite, int randomX, int randomY) : base(netSprite)
        {
            Alive = true; // else wouldn't be on screen
            Attack = 10; // amount of damage to be done when contact with sloth
            SpriteImage = netSprite; // SpriteImage prop accepts passed in netSprite
            SpritePosition = new Vector2(randomX, randomY); // SpritePosition is the randomly generated new SpritePositon
            SpriteCenter = new Vector2(SpriteImage.Width / 2, SpriteImage.Height / 2); // Center of the sprite determined by the dimensions of the image
        }

        /// <summary>
        /// Generates a random Y coordinate for the net spawn
        /// </summary>
        /// <param name="rand">random class referrence</param>
        /// <returns></returns>
        public int NetSpawn(Random rand)
        {
            rand = new Random();
            return rand.Next(400);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="gameTime">current game time</param>
        /// <param name="roomClass">room reference</param>
        public void Update(GameTime gameTime, Room roomClass)
        {
            if (spritePosition.X > -50) // if the x coord of net is displayed on screen
            {
                spritePosition.X -= 5; // net flies to the right of the screen         
            }

            base.Update(gameTime);
        }
        /// <summary>
        /// Draw Method 
        /// </summary>
        /// <param name="gameTime">current game time</param>
        /// <param name="spriteBatch">sprite batch</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Alive)
            {
                spriteBatch.Draw(SpriteImage, SpritePosition, Color.White);
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
