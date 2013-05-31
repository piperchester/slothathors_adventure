using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    /// <summary>
    /// Handles all the saving and loading for the game.
    /// </summary>
    [Serializable()]
    public class SaveSloth
    {
        private SlothData saveSlothData;
        public static bool slothSaveRequest = false; // static allows classes to try to save, or load
        public static bool slothLoadRequest = false; 

        /// <summary>
        /// Instantiates new SaveData, assigns save data to values
        /// </summary>
        public SaveSloth()
        {
        }

        /// <summary>
        /// Saves the game in the same directory as the executable.
        /// </summary>
        private void SaveGame(Sloth slothClass)
        {
            saveSlothData = new SlothData() // prime SaveData for saving game info
            {
                health = slothClass.Health,
                attack = slothClass.Attack,
                experience = slothClass.Experience,
                position = slothClass.SpritePosition
            };

            DeleteExisting(); // Deletes old files if they exist
            System.IO.StreamWriter file = new System.IO.StreamWriter("SlothSave.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(SlothData));
            serializer.Serialize(file, saveSlothData);
            file.Close();
        }

        /// <summary>
        /// Loads the game from the save file.
        /// </summary>
        public void LoadGame(Sloth slothClass)
        {
            TextReader XMLReader = new StreamReader("SlothSave.xml"); // creates new StreamReader which reads in the file path
            XmlSerializer deserializer = new XmlSerializer(typeof(SlothData));
            saveSlothData = (SlothData)deserializer.Deserialize(XMLReader);
            slothClass.Health = saveSlothData.health;
            slothClass.Attack = saveSlothData.attack;
            slothClass.Experience = saveSlothData.experience;
            slothClass.SpritePosition = saveSlothData.position;
            XMLReader.Close();
        }

        /// <summary>
        /// Deletes a previously saved file, if one exists
        /// </summary>
        private void DeleteExisting()
        {
            if (File.Exists("SlothSave.xml"))
                File.Delete("SlothSave.xml");
        }

        /// <summary>
        /// Checks every frame for a new request to save
        /// </summary>
        public void Update(GameTime gameTime, Sloth slothClass)
        {
            if (slothSaveRequest)
            {
                SaveGame(slothClass);
                slothSaveRequest = false;
            }
            else if (slothLoadRequest)
            {
                LoadGame(slothClass);
                slothLoadRequest = false;
            }
        }
    }
}