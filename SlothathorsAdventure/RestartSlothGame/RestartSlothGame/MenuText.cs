using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    /// <summary>
    /// Prints out the text for the Menus
    /// </summary>
    sealed class MenuText
    {
        /// <summary>
        /// Title Screen Text
        /// </summary>
        /// <param name="spriteBatch">sprite batch used to draw text</param>
        /// <param name="fontDict">dictonary of fonts, key required to access different fonts</param>
        public void TitleScreen(SpriteBatch spriteBatch, Dictionary<string, SpriteFont> fontDict)
        {
            spriteBatch.DrawString(fontDict["Title"], "Slothathor's", new Vector2(100, 40), Color.Black);
            spriteBatch.DrawString(fontDict["Title"], "Adventure: ", new Vector2(240, 95), Color.Black);
            spriteBatch.DrawString(fontDict["Medium"], "Press ENTER", new Vector2(620, 420), Color.Coral);
        }

        /// <summary>
        /// Info Screen Text
        /// </summary>
        /// <param name="spriteBatch">sprite batch used to draw text</param>
        /// <param name="fontDict">dictonary of fonts, key required to access different fonts</param>
        public void InfoScreen(SpriteBatch spriteBatch, Dictionary<string, SpriteFont> fontDict)
        {
            spriteBatch.DrawString(fontDict["Medium"], "Background Info ", new Vector2(70, 65), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Being folivorous creatures, sloth diets consist mainly of leaves and flower buds.", new Vector2(70, 100), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Sloths are also known for their intense lack of movement or aggression.", new Vector2(70, 120), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Their claws represent their only form of defense or attack.", new Vector2(70, 140), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "To hone their attack, rocks provide a means to sharpen their claws.", new Vector2(70, 160), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Sloths' top predators include greedy poachers' nets, and the fierce jaguar.", new Vector2(70, 180), Color.Black);
            spriteBatch.DrawString(fontDict["Medium"], "In the Jungle...", new Vector2(70, 230), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Use the Arrow Keys to Explore the jungle", new Vector2(70, 260), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Press C to Claw away any dangerous jaguars", new Vector2(70, 280), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Press D to Defend and brace against jaguar attacks", new Vector2(70, 300), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Pickup FLOWERS and LEAVES to increase health", new Vector2(70, 320), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Use ROCKS to sharpen Slothathor's claws", new Vector2(70, 340), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Watch out for the nets! You will be instantly captured by poachers and lose the game.", new Vector2(70, 360), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "During the game press H  to access this screen or ESC to quit the program", new Vector2(70, 380), Color.Black);
            spriteBatch.DrawString(fontDict["Medium"], "Press B to enter the jungle...", new Vector2(400, 420), Color.Coral);
        }



        /// <summary>
        /// GameOver Screen Text
        /// </summary>
        /// <param name="spriteBatch">sprite batch used to draw text</param>
        /// <param name="fontDict">dictonary of fonts, key required to access different fonts</param>
        public void GameOverScreen(SpriteBatch spriteBatch, Dictionary<string, SpriteFont> fontDict)
        {
            spriteBatch.DrawString(fontDict["Title"], "Game Over", new Vector2(250, 50), Color.Indigo);
            spriteBatch.DrawString(fontDict["Small"], "Press A to begin the adventure again", new Vector2(480, 420), Color.Coral);
            spriteBatch.DrawString(fontDict["Medium"], "You didn't survive the Jungle...", new Vector2(200, 110), Color.Black);
        }

        /// <summary>
        /// Win Screen Text
        /// </summary>
        /// <param name="spriteBatch">sprite batch used to draw text</param>
        /// <param name="fontDict">dictonary of fonts, key required to access different fonts</param>
        public void WinScreen(SpriteBatch spriteBatch, Dictionary<string, SpriteFont> fontDict, Sloth slothClass)
        {
            spriteBatch.DrawString(fontDict["Title"], "You made it home!", new Vector2(180, 50), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Press A to begin the adventure again", new Vector2(480, 420), Color.Coral);
            spriteBatch.DrawString(fontDict["Small"], "Final Health: " + slothClass.Health, new Vector2(20, 360), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Final Claw Sharpness: " + slothClass.Attack, new Vector2(20, 380), Color.Black);
            spriteBatch.DrawString(fontDict["Small"], "Final Experience: " + slothClass.Experience, new Vector2(20, 400), Color.Black);
        }

        public void Stats(SpriteBatch spriteBatch, Dictionary<string, SpriteFont> fontDict, Sloth slothClass, Room roomClass)
        {
            // Displaying Sloth Attributes (Health, Attack, Room#, Experience)
            spriteBatch.DrawString(fontDict["Small"], "Health: " + slothClass.Health, new Vector2(20, 20), Color.Crimson);
            spriteBatch.DrawString(fontDict["Small"], "Claw Sharpness: " + slothClass.Attack, new Vector2(20, 40), Color.BurlyWood);
            spriteBatch.DrawString(fontDict["Small"], "Room Number: " + (roomClass.RoomNumber + 1), new Vector2(20, 60), Color.Ivory);
            spriteBatch.DrawString(fontDict["Small"], "Experience: " + slothClass.Experience, new Vector2(20, 80), Color.Gainsboro);
        }
    }
}
