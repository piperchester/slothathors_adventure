using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    /// <summary>
    /// Jaguar Class, extends Character and implements IDraw_Update
    /// </summary>
    sealed class Jaguar : Character, IDraw_Update
    {
        #region Fields

        /// <summary>
        /// Constant value for health of jaguar
        /// </summary>
        public const int HEALTH = 100;
        /// <summary>
        /// Constant value for attack of jaguar
        /// </summary>
        public const int ATTACK = 3;
        /// <summary>
        /// Constant value for experience gained by defeating jaguar
        /// </summary>
        public const int EXPERIENCE = 50;

        public new static int health;
        public new static int attack;
        public new static int experience;

        #endregion

        Queue<Vector2> jaguarMovement = new Queue<Vector2>();

        /// <summary>
        /// Constructor for Jaguar
        /// </summary>
        /// <param name="jaguarSprite">jaguar image</param>
        /// <param name="randomX">random X position</param>
        /// <param name="randomY">random Y position</param>
        public Jaguar(Texture2D jaguarSprite, int randomX, int randomY) : base(jaguarSprite)
        {
            Alive = true;
            Health = HEALTH;
            Attack = ATTACK;
            SpriteImage = jaguarSprite;
            SpritePosition = new Vector2(randomX, randomY);
            SpriteCenter = new Vector2(SpriteImage.Width / 2, SpriteImage.Height / 2);
            jaguarMovement.enqueue(SpritePosition + new Vector2(-100, 0));
            jaguarMovement.enqueue(SpritePosition + new Vector2(-100, -100));
            jaguarMovement.enqueue(SpritePosition + new Vector2(0, -100));
            jaguarMovement.enqueue(SpritePosition + new Vector2(0, 0));
        }

        /// <summary>
        /// Check's jaguar's logic
        /// </summary>
        /// <param name="gameTime"></param>
        public new void Update(GameTime gameTime)
        {
            if (spritePosition.X > jaguarMovement[0].X)
            {
                spritePosition.X -= 2;
            }
            if (spritePosition.X < jaguarMovement[0].X)
            {
                spritePosition.X += 2;
            }
            if (spritePosition.Y < jaguarMovement[0].Y)
            {
                spritePosition.Y += 2;
            }
            if (spritePosition.Y > jaguarMovement[0].Y)
            {
                spritePosition.Y -= 2;
            }
            if (SpritePosition == jaguarMovement[0])
            {
                jaguarMovement.enqueue(SpritePosition);
                jaguarMovement.dequeue();
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
