using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    /// <summary>
    /// Flower class extends Item and implements IDraw_Update
    /// </summary>
    sealed class Flower : Item, IDraw_Update
    {
        /// <summary>
        /// Constant value for increase of health if flower is picked up
        /// </summary>
        public const int HEALTH = 20;

        /// <summary>
        /// Health value assigned to when XML is read in
        /// </summary>
        public new static int health;

        /// <summary>
        /// Flower constructor
        /// </summary>
        /// <param name="flowerSprite">accepts flower image</param>
        /// <param name="randomX">accepts random X coordinate</param>
        /// <param name="randomY">accepts random Y coordinate</param>
        public Flower(Texture2D flowerSprite, int randomX, int randomY) : base(flowerSprite)
        {
            Alive = true;
            SpriteImage = flowerSprite;
            SpritePosition = new Vector2 (randomX, randomY);
        }
        /// <summary>
        /// Update Method updates logic of class
        /// </summary>
        /// <param name="gameTime">current game time</param>
        public new void Update(GameTime gameTime)
        {
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
