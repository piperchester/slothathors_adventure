using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SlothathorRestart
{
    /// <summary>
    /// Sloth class
    /// </summary>
    [Serializable()]
    public class Sloth : Character, ISlothMovement, IDraw_Update
    {
        #region Fields

        /// <summary>
        /// Starting health value
        /// </summary>
        public const int INITIAL_HEALTH = 100;
        /// <summary>
        /// Starting attack value
        /// </summary>
        public const int INITIAL_ATTACK = 5;
        /// <summary>
        /// Starting experience value
        /// </summary>
        public const int INITIAL_EXPERIENCE = 0;
        /// <summary>
        /// Initial X value for sloth
        /// </summary>
        public const int X_START = 1;
        /// <summary>
        /// Inital Y value for sloth
        /// </summary>
        public const int Y_START = 450;
        /// <summary>
        /// X value when Sloth goes back a room
        /// </summary>
        public const int X_PREVIOUS = 670;
        /// <summary>
        /// the sloth image
        /// </summary>
        private Texture2D defaultSlothSprite;
        /// <summary>
        /// The claw image
        /// </summary>
        private Texture2D clawSprite;
        /// <summary>
        /// Defend image
        /// </summary>
        private Texture2D defendSprite;

        #region Static Values assigned to by XML Read In

        public static int initialHealth;
        public static int initialAttack;
        public static int initialExperience;
        public static int xStart;
        public static int yStart;
        public static int xPrevious;

        #endregion

        #endregion

        /// <summary>
        /// Default constructor required for save/load 
        /// </summary>
        public Sloth() { }

        /// <summary>
        /// Sloth constructor
        /// </summary>
        /// <param name="slothSprite">sloth image</param>
        /// <param name="defaultSlothSprite">sloth image</param>
        /// <param name="clawSprite">claw image</param>
        /// <param name="defendSprite">defend image</param>
        public Sloth(Texture2D slothSprite, Texture2D defaultSlothSprite, Texture2D clawSprite, Texture2D defendSprite) : base(slothSprite)
        {
            Alive = true;
            SpriteImage = slothSprite;
            this.defaultSlothSprite = defaultSlothSprite;
            this.clawSprite = clawSprite;
            this.defendSprite = defendSprite;
            SpriteCenter = new Vector2(SpriteImage.Width / 2, SpriteImage.Height / 2);
            InitializeSloth();
        }

        // controls movement of character
        public new void SlothMovement(int changeX, int changeY)
        {
            SpritePosition += new Vector2(changeX, changeY);
        }

        /// <summary>
        /// Resets all sloth stats to initial state
        /// </summary>
        public void InitializeSloth()
        {
            Health = INITIAL_HEALTH;
            Attack = INITIAL_ATTACK;
            Experience = INITIAL_EXPERIENCE;
            SpritePosition = new Vector2(X_START, Y_START);
        }

        /// <summary>
        /// Update Method updates logic of class
        /// </summary>
        /// <param name="gameTime">current game time</param>
        /// <param name="keyboardState">current state of keyboard</param>
        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {           
            Alive = true;

            #region Key Presses (Movement, Attacking, Defending)

            // Movement and Attack and Defense Loading
            if (keyboardState.IsKeyDown(Keys.Left))
                SlothMovement(-3, 0);

            if (keyboardState.IsKeyDown(Keys.Right))
                SlothMovement(3, 0);

            if (keyboardState.IsKeyDown(Keys.Up))
                SlothMovement(0, -3);

            if (keyboardState.IsKeyDown(Keys.Down))
                SlothMovement(0, 3);

            if (!keyboardState.IsKeyDown(Keys.C))
                SpriteImage = defaultSlothSprite;

            else if (keyboardState.IsKeyDown(Keys.C))
            {
                SpriteImage = clawSprite;
            }

            if (keyboardState.IsKeyDown(Keys.D))

            #endregion

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
