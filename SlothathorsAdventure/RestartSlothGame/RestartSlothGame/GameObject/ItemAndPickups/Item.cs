using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    /// <summary>
    /// Abstact class Item extends GameObject
    /// </summary>
    abstract class Item : GameObject
    {
        /// <summary>
        /// Item Constructor
        /// </summary>
        /// <param name="spriteImage">accepts the sprite image</param>
        public Item(Texture2D spriteImage) : base(spriteImage)
        {
            SpriteImage = spriteImage;
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
