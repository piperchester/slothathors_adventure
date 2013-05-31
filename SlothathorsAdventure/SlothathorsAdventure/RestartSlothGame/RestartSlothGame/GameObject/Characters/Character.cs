using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    /// <summary>
    /// Abstract class Characted extends GameObject
    /// </summary>
    public abstract class Character : GameObject
    {
        #region Fields and Properties

        /// <summary>
        /// X and Y position of sprite center
        /// </summary>
        private Vector2 spriteCenter;

        /// <summary>
        /// Property for spriteCenter
        /// </summary>
        public Vector2 SpriteCenter
        {
            get { return spritePosition + new Vector2(spriteImage.Width / 2, spriteImage.Height / 2); }
            set { spriteCenter = value; }
        }

        #endregion

        public Character() { } 

        /// <summary>
        /// Character Constructor
        /// </summary>
        /// <param name="spriteImage">Default texture</param>
        public Character(Texture2D spriteImage) : base(spriteImage)
        {
            Alive = true;
            SpriteImage = spriteImage;
            SpritePosition = new Vector2(0, 450);
            SpriteCenter = SpriteCenter;
        }
        /// <summary>
        /// Will direct the movement of the sloth by accepting two integer values to use as the X and Y coordinates
        /// </summary>
        /// <param name="posX">X coord</param>
        /// <param name="posY">Y coord</param>
        public override void SlothMovement(int posX, int posY) { }

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
