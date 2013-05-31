using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    /// <summary>
    /// Menu Class extends GameObject
    /// </summary>
    public class Menu : GameObject
    {
        #region Fields and Properties

        /// <summary>
        /// Number of the menu
        /// </summary>
        private int menuNumber;
        /// <summary>
        /// Whether or not a screen is open
        /// </summary>
        private bool menuOpen;

        /// <summary>
        /// Property for menu number
        /// </summary>
        public int MenuNumber
        {
            get { return menuNumber; }
            set { menuNumber = value; }
        }
        /// <summary>
        /// Property for menu open
        /// </summary>
        public bool MenuOpen
        {
            get { return menuOpen; }
            set { menuOpen = value; }
        }

        #endregion

        /// <summary>
        /// Menu Constructor
        /// </summary>
        /// <param name="menuTexture">menu image</param>
        /// <param name="viewPortRect">view port rectangle</param>
        /// <param name="menuNumber">menu number</param>
        public Menu(Texture2D menuTexture, Rectangle viewPortRect, int menuNumber) : base(menuTexture)
        {
            Alive = false;
            MenuOpen = true;
            MenuNumber = menuNumber; // assigns parameter to property
            SpriteImage = menuTexture; // assigns parameter to property
            SpriteRectangle = viewPortRect; // assigns parameter to property
        }
        /// <summary>
        /// Draw Method 
        /// </summary>
        /// <param name="gameTime">current game time</param>
        /// <param name="spriteBatch">sprite batch</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (MenuOpen)
            {
                spriteBatch.Draw(SpriteImage, SpriteRectangle, Color.White);
            }
        }
    }
}
