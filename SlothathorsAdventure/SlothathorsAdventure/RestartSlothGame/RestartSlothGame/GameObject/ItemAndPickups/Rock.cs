using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    /// <summary>
    /// Rock Class, extends from Item and Implements IDraw_Update
    /// </summary>
    class Rock : Item, IDraw_Update
    {
        /// <summary>
        /// Constant value for increase of experience if rock is picked up
        /// </summary>
        public const int EXPERIENCE = 10;

        /// <summary>
        /// Experience value used for when XML is passed in
        /// </summary>
        public new static int experience;

        /// <summary>
        /// Rock Constructor
        /// </summary>
        /// <param name="rockImage">rock texture image</param>
        /// <param name="randomX">randomly assigned x coordinate</param>
        /// <param name="randomY">randomly assigned y coordinate</param>
        public Rock(Texture2D rockImage, int randomX, int randomY) : base(rockImage)
        {
            Alive = true;
            SpriteImage = rockImage;
            SpritePosition = new Vector2(randomX, randomY);
        }
        /// <summary>
        /// Update Method
        /// </summary>
        /// <param name="gameTime">game time of the update</param>
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

