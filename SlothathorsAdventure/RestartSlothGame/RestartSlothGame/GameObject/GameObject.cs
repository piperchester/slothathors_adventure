using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    public abstract class GameObject
    {
        #region Fields and Properties

        /// <summary>
        /// whether object should be drawn on screen
        /// </summary>
        protected bool alive;
        /// <summary>
        /// name of class
        /// </summary>
        protected string className;
        /// <summary>
        /// x and y coordinates of object
        /// </summary>
        public Vector2 spritePosition;
        /// <summary>
        /// image texture
        /// </summary>
        protected Texture2D spriteImage;
        /// <summary>
        /// the size of this rectangle determines the size of the image being drawn
        /// </summary>
        protected Rectangle spriteRectangle;
        /// <summary>
        /// attack stored as an integer
        /// </summary>
        protected int attack;
        /// <summary>
        /// experience store as an int
        /// </summary>
        protected int experience;
        /// <summary>
        /// amount that will be added to sloth by pickups, or detracted from enemies
        /// </summary>
        protected int health;
        /// <summary>
        /// Property for alive
        /// </summary>
        public virtual bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }
        /// <summary>
        /// Property for className
        /// </summary>
        public virtual String ClassName
        {
            get { return className; }
            set { className = "GameObject"; }
        }
        /// <summary>
        /// Property for spritePosition
        /// </summary>
        public virtual Vector2 SpritePosition
        {
            get { return spritePosition; }
            set { spritePosition = value; }
        }
        /// <summary>
        /// Property for spriteImage
        /// </summary>
        public virtual Texture2D SpriteImage
        {
            get { return spriteImage; }
            set { spriteImage = value; }
        }
        /// <summary>
        /// Property for spriteRectangle
        /// </summary>
        public virtual Rectangle SpriteRectangle
        {
            get 
            {
                if (this is Room || this is Menu)
                {
                    return spriteRectangle;
                }
                else
                {
                    return new Rectangle((int)SpritePosition.X, (int)SpritePosition.Y, SpriteImage.Width, SpriteImage.Height);
                }
            }
            set { spriteRectangle = value; }
        }
        /// <summary>
        /// Property for attack
        /// </summary>
        public virtual int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
        /// <summary>
        /// Property for experience
        /// </summary>
        public virtual int Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        /// <summary>
        /// Property for health
        /// </summary>
        public virtual int Health
        {
            get
            {
                if (health <= 0)
                {
                    alive = false;
                    return health = 0;
                }
                else { return health; }
            }
            set { health = value; }
        }

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public GameObject() { }

        /// <summary>
        /// GameObject constructor
        /// </summary>
        /// <param name="spriteImage">texture image</param>
        public GameObject(Texture2D spriteImage) : this()
        {
            this.spriteImage = spriteImage;
            spritePosition = Vector2.Zero; // resets sprite position to (0,0)
            alive = true;
        }

        /// <summary>
        /// Accepts position for Sloth Movement
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        public virtual void SlothMovement(int posX, int posY) { }
        /// <summary>
        /// Update Method updates logic of class
        /// </summary>
        /// <param name="gameTime">current game time</param>
        public void Update(GameTime gameTime) { }
        /// <summary>
        /// ToString method
        /// </summary>
        /// <returns>class name</returns>
        public override string ToString()
        {
            return className;
        }
    }
}
