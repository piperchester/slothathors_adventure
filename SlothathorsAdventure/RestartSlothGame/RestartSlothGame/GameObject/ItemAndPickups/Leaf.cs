using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SlothathorRestart
{
    /// <summary>
    /// Leaf class that extends Item and implements IDraw_Update
    /// </summary>
    sealed class Leaf : Item, IDraw_Update
    {
        /// <summary>
        /// Constant value for increase of health if leaf is picked up
        /// </summary>
        public const int HEALTH = 10;

        /// <summary>
        /// Health value assigned to when XML is read
        /// </summary>
        public new static int health;

        /// <summary>
        /// Leaf Constructor
        /// </summary>
        /// <param name="leafSprite">image of the leaf</param>
        /// <param name="randomX">random X coordinate</param>
        /// <param name="randomY">random Y coordinate</param>
        public Leaf(Texture2D leafSprite, int randomX, int randomY) : base(leafSprite)
        {
            Alive = true;
            SpriteImage = leafSprite;
            SpritePosition = new Vector2(randomX, randomY);
        }

        /// <summary>
        /// Update Method updates logic of class
        /// </summary>
        /// <param name="gameTime">current game time</param>
        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw Method 
        /// </summary>
        /// <param name="gameTime">current game time</param>
        /// <param name="spriteBatch">sprite batch</param>s
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
