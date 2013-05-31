using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    /// <summary>
    /// Room class that extends GameObject and IDraw_Update
    /// </summary>
    [Serializable()]
    public class Room : GameObject, IDraw_Update
    {
        #region Fields and Properties

        /// <summary>
        /// The ID of the room stored as an int
        /// </summary>
        private int roomNumber;
        /// <summary>
        /// Number of leaves in room
        /// </summary>
        private int leafNumber;
        /// <summary>
        /// Number of flowers per level
        /// </summary>
        private int flowerNumber;
        /// <summary>
        /// Number of rocks per level
        /// </summary>
        private int rockNumber;
        /// <summary>
        /// Number of jaguars per level
        /// </summary>
        private int jaguarNumber;
        /// <summary>
        /// Number of nets per level
        /// </summary>
        private int netNumber;

        /// <summary>
        /// Property for Room Number
        /// </summary>
        public int RoomNumber
        {
            get { return roomNumber; }
            set { roomNumber = value; }
        }
        /// <summary>
        /// Property for Leaf Number
        /// </summary>
        public int LeafNumber
        {
            get { return leafNumber; }
            set { leafNumber = value; }
        }
        /// <summary>
        /// Property for Flower Number
        /// </summary>
        public int FlowerNumber
        {
            get { return flowerNumber; }
            set { flowerNumber = value; }
        }
        /// <summary>
        /// Property for Rock Number
        /// </summary>
        public int RockNumber
        {
            get { return rockNumber; }
            set { rockNumber = value; }
        }
        /// <summary>
        /// Property for Jaguar Number
        /// </summary>
        public int JaguarNumber
        {
            get { return jaguarNumber; }
            set { jaguarNumber = value; }
        }
        /// <summary>
        /// Property for Net Number
        /// </summary>
        public int NetNumber
        {
            get { return netNumber; }
            set { netNumber = value; }
        }

#endregion

        public Room() { }

        /// <summary>
        /// Room Constructor
        /// </summary>
        /// <param name="roomTexture">background image of room</param>
        /// <param name="viewPortRect">the rectangle of the view port</param>
        /// <param name="roomNumber">number of room</param>
        /// <param name="leafNumber">how many leaves for that room</param>
        /// <param name="flowerNumber">how many flowers for that room</param>
        /// <param name="rockNumber">how many rocks for that room</param>
        /// <param name="jaguarNumber">how jaguars for that room</param>
        /// <param name="netNumber">how many nets for that room</param>
        public Room(Texture2D roomTexture, Rectangle viewPortRect, int roomNumber, int leafNumber, int flowerNumber, int rockNumber, int jaguarNumber, int netNumber) : base(roomTexture)
        {
            Alive = true; // if not Alive, will not be drawn
            RoomNumber = roomNumber; // assigns parameter to property
            SpriteImage = roomTexture; // assigns parameter to property
            LeafNumber = leafNumber; // assigns parameter to property
            FlowerNumber = flowerNumber; // assigns parameter to property
            RockNumber = rockNumber; // assigns parameter to property
            JaguarNumber = jaguarNumber; // assigns parameter to property
            NetNumber = netNumber; // assigns parameter to property
            SpriteRectangle = viewPortRect; // assigns parameter to property
        }

        /// <summary>
        /// Sets Room Number to 0
        /// </summary>
        public void InitializeRoom()
        {
            RoomNumber = 0; // sets room number to 0, the 1st level
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
                spriteBatch.Draw(SpriteImage, SpriteRectangle, Color.White);
            }
        }
    }
}
