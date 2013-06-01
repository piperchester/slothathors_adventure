using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace SlothathorRestart
{
    /// <summary>
    /// This is the main type of the game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region Fields

        /// <summary>
        /// Default manager used to draw graphics
        /// </summary>
        GraphicsDeviceManager graphics;
        /// <summary>
        /// Contains the ability to draw sprites
        /// </summary>
        SpriteBatch spriteBatch;
        /// <summary>
        /// Size of the screen being displayed
        /// </summary>
        Rectangle viewPortRect;
        /// <summary>
        /// Room class reference
        /// </summary>
        Room roomClass;
        /// <summary>
        /// Menu class reference
        /// </summary>
        Menu menuClass;
        /// <summary>
        /// Sloth class reference
        /// </summary>
        Sloth slothClass;
        /// <summary>
        /// SpawnNet class reference
        /// </summary>
        SpawnNet spawnNet;
        /// <summary>
        /// Random class instantiaion
        /// </summary>
        Random rand;
        /// <summary>
        /// List of leaf classes
        /// </summary>
        List<Leaf> leaves;
        /// <summary>
        /// List of flower classes
        /// </summary>
        List<Flower> flowers;
        /// <summary>
        /// List of rock classes
        /// </summary>
        List<Rock> rocks;
        /// <summary>
        /// List of jaguar classes
        /// </summary>
        List<Jaguar> jaguars;
        /// <summary>
        /// LIFO data structure that contains 5 net classes
        /// </summary>
        Stack<Net> nets;
        /// <summary>
        /// Whether or not the game draws the menu to the screen
        /// </summary>
        bool menuOpen;
        /// <summary>
        /// Contains keys and values for all images being loaded
        /// </summary>
        Dictionary<string, Texture2D> spriteDict;
        /// <summary>
        /// Contains keys and values for all fonts of the game
        /// </summary>
        Dictionary<string, SpriteFont> fontDict;
        /// <summary>
        /// Array of menu classes
        /// </summary>
        Menu[] menus;
        /// <summary>
        /// Array of Rooms
        /// </summary>
        Room[] levels;
        /// <summary>
        /// Array of Spritefonts
        /// </summary>
        SpriteFont[] fonts;
        /// <summary>
        /// Class that clears and populates all lists
        /// </summary>
        ListManagement listManagement;
        /// <summary>
        /// Draws all text to menu screens
        /// </summary>
        MenuText menuText;
        /// <summary>
        /// Serializes sloth class through XML
        /// </summary>
        SaveSloth saveSloth;
        /// <summary>
        /// Serializes room class through XML
        /// </summary>
        SaveRoom saveRoom;
        /// <summary>
        /// Writes out constants through XML
        /// </summary>
        WriteOutConsts writeOutConsts;
        /// <summary>
        /// Reads in XML files and assigns them to fields
        /// </summary>
        ReadIn readIn;
        /// <summary>
        /// Used to assign constants to values if issue with read in XML
        /// </summary>
        ConstantsAssigning assignConsts;
        /// <summary>
        /// Dictonary of sounds
        /// </summary>
        public static Dictionary<string, SoundEffect> soundDict;

        #endregion

        #region Constants and Static Values

        public const int NUMBER_OF_MENUS = 4;
        public const int JAGUAR_NUMBER = 1;
        public const int PICKUP_NUMBER = 1;
        public const int NUMBER_OF_LEVELS = 4;
        public const int NET_NUMBER = 1;

        public static int numberOfMenus;
        public static int jaguarNumber;
        public static int pickupNumber;
        public static int numberOfLevels;
        public static int netNumber;

        #endregion

        /// <summary>
        /// Default method required to run game
        /// </summary>
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this); // default required to run game
            Content.RootDirectory = "Content"; // default required to run game
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            assignConsts = new ConstantsAssigning();
            readIn = new ReadIn();
            writeOutConsts = new WriteOutConsts();
            spriteDict = new Dictionary<string, Texture2D>();
            fontDict = new Dictionary<string, SpriteFont>();
            soundDict = new Dictionary<string, SoundEffect>();
            nets = new Stack<Net>(5);
            jaguars = new List<Jaguar>();
            rocks = new List<Rock>();
            flowers = new List<Flower>();
            leaves = new List<Leaf>();
            spawnNet = new SpawnNet();
            menuText = new MenuText();
            listManagement = new ListManagement();
            rand = new Random();
            saveSloth = new SaveSloth();
            saveRoom = new SaveRoom();
            fonts = new SpriteFont[3];
            levels = new Room[4];
            menus = new Menu[4];
            spriteBatch = new SpriteBatch(GraphicsDevice); // Create a new SpriteBatch, which can be used to draw textures.
            viewPortRect = new Rectangle(0, 0, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height); // creates new rectangle with the same dimensions as the screen    
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            #region Dictonary Loading 

            // Loads all sprites into their respective dictonary keys
            spriteDict.Add("darkJungle", Content.Load<Texture2D>("Sprites\\Backgrounds\\darkJungle"));
            spriteDict.Add("gameOver", Content.Load<Texture2D>("Sprites\\Backgrounds\\gameOver"));
            spriteDict.Add("winScreen", Content.Load<Texture2D>("Sprites\\Backgrounds\\winScreen"));
            spriteDict.Add("greenJungle", Content.Load<Texture2D>("Sprites\\Backgrounds\\greenJungle"));
            spriteDict.Add("infoScreen", Content.Load<Texture2D>("Sprites\\Backgrounds\\infoScreen"));
            spriteDict.Add("jungleTree", Content.Load<Texture2D>("Sprites\\Backgrounds\\jungleTree"));
            spriteDict.Add("smallTitle", Content.Load<Texture2D>("Sprites\\Backgrounds\\smallTitle"));
            spriteDict.Add("waterfall", Content.Load<Texture2D>("Sprites\\Backgrounds\\waterfall"));
            spriteDict.Add("jaguar", Content.Load<Texture2D>("Sprites\\Characters\\jaguarFinal"));
            spriteDict.Add("slothathor", Content.Load<Texture2D>("Sprites\\Characters\\finalSloth1"));
            spriteDict.Add("slothathorClaws", Content.Load<Texture2D>("Sprites\\Characters\\sloth2"));
            spriteDict.Add("slothathorDefend", Content.Load<Texture2D>("Sprites\\Characters\\slothathorDefend"));
            spriteDict.Add("flower", Content.Load<Texture2D>("Sprites\\Pickups\\smallFlower"));
            spriteDict.Add("leaf", Content.Load<Texture2D>("Sprites\\Pickups\\leafFinal"));
            spriteDict.Add("sharpeningRock", Content.Load<Texture2D>("Sprites\\Pickups\\rockFinal"));
            spriteDict.Add("zap", Content.Load<Texture2D>("Sprites\\Characters\\smallNet"));
            
            // Adds fonts to their keys
            fontDict.Add("Medium", Content.Load<SpriteFont>("Fonts\\MediumFont"));
            fontDict.Add("Small", Content.Load<SpriteFont>("Fonts\\SmallFont"));
            fontDict.Add("Title", Content.Load<SpriteFont>("Fonts\\TitleFont"));

            // Adds sounds to their keys
            soundDict.Add("intro", Content.Load<SoundEffect>("Sounds\\beginningGame"));
            soundDict.Add("jaguarCry", Content.Load<SoundEffect>("Sounds\\jaguarCry"));
            soundDict.Add("leafCrunch", Content.Load<SoundEffect>("Sounds\\leafCrunch"));
            soundDict.Add("rockScrape", Content.Load<SoundEffect>("Sounds\\rockScrape"));
            soundDict.Add("netWoosh", Content.Load<SoundEffect>("Sounds\\netWoosh"));
            soundDict.Add("slothScratch", Content.Load<SoundEffect>("Sounds\\slothScratch"));
           
            // Populates arrays with new Rooms and Menus
            levels[0] = new Room(spriteDict["darkJungle"], viewPortRect, 0, 1, rand.Next(3), rand.Next(3), rand.Next(2), 1);
            levels[1] = new Room(spriteDict["greenJungle"], viewPortRect, 1, 1, rand.Next(4), rand.Next(2), rand.Next(2), 1);
            levels[2] = new Room(spriteDict["jungleTree"], viewPortRect, 2, 1, rand.Next(2), rand.Next(4), rand.Next(2), 1);
            levels[3] = new Room(spriteDict["waterfall"], viewPortRect, 3, 1, rand.Next(2), rand.Next(2), rand.Next(2), 1);
            menus[0] = new Menu(spriteDict["smallTitle"], viewPortRect, 0);
            menus[1] = new Menu(spriteDict["infoScreen"], viewPortRect, 1);
            menus[2] = new Menu(spriteDict["gameOver"], viewPortRect, 2);
            menus[3] = new Menu(spriteDict["winScreen"], viewPortRect, 2);
            fonts[0] = fontDict["Medium"];
            fonts[1] = fontDict["Title"];
            fonts[2] = fontDict["Small"];

            
            #endregion

            menuOpen = true; // initial screen will be the title screen (a menu)
            menuClass = menus[0]; // loads the first menu into the menu class
            roomClass = levels[0]; // load first level into the room class
            slothClass = new Sloth(spriteDict["slothathor"], spriteDict["slothathor"], spriteDict["slothathorClaws"], spriteDict["slothathorDefend"]); // loads all sloth sprites into sloth classes
            soundDict["intro"].Play(.25f,0,0);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload all content.
        /// </summary>
        protected override void UnloadContent() { }

        /// <summary>
        /// Allows the game to run logic such as updating the world, checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            KeyboardState currentKeyboardState = Keyboard.GetState(); // gets the current state of the keyboard
            
            if (currentKeyboardState.IsKeyDown(Keys.Escape)) // will close program if escape key is pressed
                Environment.Exit(0);

            // All Logic that occurs during a menu is open (main screen, info screen, and game over)
            if (menuOpen)
            {
                // Getting Past Initial Menus
                if (menuClass.MenuNumber == 0)
                {
                    if (currentKeyboardState.IsKeyDown(Keys.Enter))
                    {
                        menuClass = menus[1]; // sets menu class to the info screen
                        roomClass = levels[0] = new Room(spriteDict["darkJungle"], viewPortRect, 0, PICKUP_NUMBER, PICKUP_NUMBER, PICKUP_NUMBER, JAGUAR_NUMBER, NET_NUMBER); // loads the level and pickups into the 0th index of the level array
                        levels[1] = new Room(spriteDict["greenJungle"], viewPortRect, 1, PICKUP_NUMBER, PICKUP_NUMBER, PICKUP_NUMBER, JAGUAR_NUMBER, NET_NUMBER); // loads the level and pickups into the 0th index of the level array
                        levels[2] = new Room(spriteDict["jungleTree"], viewPortRect, 2, PICKUP_NUMBER, PICKUP_NUMBER, PICKUP_NUMBER, JAGUAR_NUMBER, NET_NUMBER); // loads the level and pickups into the 0th index of the level array
                        levels[3] = new Room(spriteDict["waterfall"], viewPortRect, 3, PICKUP_NUMBER, PICKUP_NUMBER, PICKUP_NUMBER, JAGUAR_NUMBER, NET_NUMBER); // loads the level and pickups into the 0th index of the level array                        
                        roomClass.InitializeRoom();
                        slothClass.InitializeSloth();
                        listManagement.ClearAndPopulate(leaves, flowers, rocks, jaguars, viewPortRect, rand, spriteDict, roomClass);
                        writeOutConsts.RoomConsts();
                        writeOutConsts.SlothConsts();
                        writeOutConsts.ItemConsts();
                    }
                }

                // Enter the game
                if (menuClass.MenuNumber == 1)
                    if (currentKeyboardState.IsKeyDown(Keys.B))
                        menuOpen = false;

                // Goes back to main screen
                if (menuClass.MenuNumber == 2 || menuClass.MenuNumber == 3)
                    if (currentKeyboardState.IsKeyDown(Keys.A))
                        menuClass = menus[0];
            }
            else
            {
                spawnNet.SpawnANet(gameTime, 1, nets, spriteDict);  // Call SpawnNet to send net across screen, pass in GameTime
                spawnNet.RemoveNet(roomClass, nets); // Call SpawnNet to remove net

                #region Clamping Movement

                slothClass.spritePosition.Y = MathHelper.Clamp(slothClass.SpritePosition.Y, 0.0f, graphics.GraphicsDevice.Viewport.Height - (slothClass.SpriteImage.Height - 40)); // Restricting vertical sloth movement
                if (roomClass.RoomNumber == 0)
                    slothClass.spritePosition.X = MathHelper.Clamp(slothClass.SpritePosition.X, 0.0f, graphics.GraphicsDevice.Viewport.Width); // Disallowing to walk back into the title screen

                #endregion

                // Game Over, sets menu to game over screen 
                if (slothClass.Health <= 0)
                {
                    menuClass = menus[2];
                    menuOpen = true;
                    soundDict["jaguarCry"].Play(.25f, 0, 0);
                }

                // Accessing Help Screen
                if (roomClass.RoomNumber >= 0)
                    if (currentKeyboardState.IsKeyDown(Keys.H))
                        menuOpen = true;

                // XML Saving stats
                if (currentKeyboardState.IsKeyDown(Keys.X))
                {
                    SaveSloth.slothSaveRequest = true;
                    SaveRoom.roomSaveRequest = true;
                }

                // XML Loading stats
                if (currentKeyboardState.IsKeyDown(Keys.L))
                {
                    SaveSloth.slothLoadRequest = true;
                    SaveRoom.roomLoadRequest = true;
                }

                // Read in XML files
                if (currentKeyboardState.IsKeyDown(Keys.R))
                {
                    // Try to read in xml files, if errors assign constants to values
                    try
                    {
                        ReadIn.RoomPassIn();
                        ReadIn.ItemPassIn();
                        ReadIn.SlothPassIn();
                    }
                    catch
                    {
                        assignConsts.Assign();
                    }
                }

                #region Sloth Collision with Objects

                // Pickup Collision with Sloth
                // remove element from list, detract 1 from number of elements for that room, add health or experience to sloth
                foreach (Leaf leaf in leaves)
                    if (slothClass.SpriteRectangle.Intersects(leaf.SpriteRectangle))
                    {
                        leaves.Del(leaf);
                        roomClass.LeafNumber--;
                        slothClass.Health += Leaf.HEALTH;
                        soundDict["leafCrunch"].Play(.25f, 0, 0);
                    }
                foreach (Flower flower in flowers)
                    if (slothClass.SpriteRectangle.Intersects(flower.SpriteRectangle))
                    {
                        flowers.Del(flower);
                        roomClass.FlowerNumber--;
                        slothClass.Health += Flower.HEALTH;
                    }

                foreach (Rock rock in rocks)
                    if (slothClass.SpriteRectangle.Intersects(rock.SpriteRectangle))
                    {
                        rocks.Del(rock);
                        roomClass.RockNumber--;
                        slothClass.Experience += Rock.EXPERIENCE;
                        soundDict["rockScrape"].Play(.25f, 0, 0);
                    }

                foreach (Net net in nets)
                    if (slothClass.SpriteRectangle.Intersects(net.SpriteRectangle))
                    {
                        slothClass.Health = 0;
                        soundDict["netWoosh"].Play(.25f,0,0);
                    }
                

                #endregion

                #region Combat

                // Combat, jaguar health subtracts from sloth attack when C is pressed and there is overlap between the 2
                for (int jaguar = 0; jaguar < jaguars.Count; jaguar++)
                {
                    if (slothClass.SpriteRectangle.Intersects(jaguars[jaguar].SpriteRectangle) && !currentKeyboardState.IsKeyDown(Keys.D))
                    {
                        if (currentKeyboardState.IsKeyDown(Keys.C))
                            jaguars[jaguar].Health -= slothClass.Attack;
                        else
                        {
                            slothClass.Health -= jaguars[jaguar].Attack;
                        }

                        // if jaguar health is less than or equal to 0, remove element from list, detract 1 from number of elements for that room, experience to sloth
                        if (jaguars[jaguar].Health <= 0)
                        {
                            jaguars.Del(jaguars[jaguar]);
                            roomClass.JaguarNumber--;
                            slothClass.Experience += Jaguar.EXPERIENCE;
                        }
                    }
                }

                #endregion

                // Loading Next Level
                foreach (Room level in levels)
                {
                    #region Moving to Next Level, Right Side of Screen

                    if (slothClass.SpriteCenter.X >= viewPortRect.Width)
                    {
                        if (roomClass.RoomNumber < levels.Count() - 1)
                        {
                            roomClass = levels[roomClass.RoomNumber + 1];
                            slothClass.SpritePosition = new Vector2(Sloth.X_START, Sloth.Y_START);
                            listManagement.ClearAndPopulate(leaves, flowers, rocks, jaguars, viewPortRect, rand, spriteDict, roomClass);
                        }
                        else
                        {
                            menuOpen = true;
                            menuClass = menus[3]; // win screen
                            menuClass.MenuNumber = 3;
                        }
                    }

                    #endregion

                    #region Moving to Previous Level, Left Side of Screen

                    if (slothClass.SpriteCenter.X < -1)
                    {
                        if (roomClass.RoomNumber >= 1) // when sloth touches left side of screen
                        {
                            slothClass.SpritePosition = new Vector2(Sloth.X_PREVIOUS, slothClass.SpritePosition.Y); // moves sloth to a new position
                            roomClass = levels[roomClass.RoomNumber - 1];
                            listManagement.ClearAndPopulate(leaves, flowers, rocks, jaguars, viewPortRect, rand, spriteDict, roomClass);
                        }
                    }

                    #endregion
                }
            }

            #region Object Update

            foreach (Leaf leaf in leaves)
                leaf.Update(gameTime);

            foreach (Flower flower in flowers)
                flower.Update(gameTime);

            foreach (Rock rock in rocks)
                rock.Update(gameTime);

            foreach (Jaguar jaguar in jaguars)
                jaguar.Update(gameTime);

            foreach (Net net in nets)
                net.Update(gameTime, roomClass);

            #endregion

            slothClass.Update(gameTime, currentKeyboardState); // calls sloth's update

            saveSloth.Update(gameTime, slothClass);
            saveRoom.Update(gameTime, roomClass);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(); // starts the sprite batch, in order to draw
            GraphicsDevice.Clear(Color.CornflowerBlue); // initially clears the graphics device

            if (menuOpen)
            {
                menuClass.Draw(gameTime, spriteBatch);

                if (menuClass.MenuNumber == 0) // Title Screen
                    menuText.TitleScreen(spriteBatch, fontDict);

                if (menuClass.MenuNumber == 1) // Info Screen
                    menuText.InfoScreen(spriteBatch, fontDict);

                if (menuClass.MenuNumber == 2) // Game Over Screen
                    menuText.GameOverScreen(spriteBatch, fontDict);
               
                if (menuClass.MenuNumber == 3) // Win Screen
                    menuText.WinScreen(spriteBatch, fontDict, slothClass);
            }
            else
            {
                roomClass.Draw(gameTime, spriteBatch);
                slothClass.Draw(gameTime, spriteBatch);

                // Calling each element's draw, passing in gametime and spritebatch
                foreach (Leaf leaf in leaves)
                    leaf.Draw(gameTime, spriteBatch);

                foreach (Flower flower in flowers)
                    flower.Draw(gameTime, spriteBatch);

                foreach (Rock rock in rocks)
                    rock.Draw(gameTime, spriteBatch);

                foreach (Jaguar jaguar in jaguars)
                    jaguar.Draw(gameTime, spriteBatch);

                foreach (Net net in nets)
                    net.Draw(gameTime, spriteBatch);
                
                menuText.Stats(spriteBatch, fontDict, slothClass, roomClass); // drawing stats
            }       

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
