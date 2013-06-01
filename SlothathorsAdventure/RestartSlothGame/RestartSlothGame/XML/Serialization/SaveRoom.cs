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
    public class SaveRoom
    {
        private RoomData saveRoomData;
        public static bool roomSaveRequest = false; // static allows classes to try to save, or load
        public static bool roomLoadRequest = false;

        /// <summary>
        /// Instantiates new SaveData, assigns save data to values
        /// </summary>
        public SaveRoom()
        {

        }

        /// <summary>
        /// Saves the game in the same directory as the executable.
        /// </summary>
        private void SaveGame(Room roomClass)
        {
            saveRoomData = new RoomData() // prime SaveData for saving game info
            {
                roomNumber = roomClass.RoomNumber,
            };

            DeleteExisting(); // Deletes old files if they exist
            System.IO.StreamWriter file = new System.IO.StreamWriter("RoomSave.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(RoomData));
            serializer.Serialize(file, saveRoomData);
            file.Close();
        }

        /// <summary>
        /// Loads the game from the save file.
        /// </summary>
        public void LoadGame(Room roomClass)
        {
            TextReader XMLReader = new StreamReader("RoomSave.xml"); // creates new StreamReader which reads in the file path
            XmlSerializer deserializer = new XmlSerializer(typeof(RoomData));
            saveRoomData = (RoomData)deserializer.Deserialize(XMLReader);
            roomClass.RoomNumber = saveRoomData.roomNumber;
            XMLReader.Close();
        }

        /// <summary>
        /// Deletes a previously saved file, if one exists
        /// </summary>
        private void DeleteExisting()
        {
            if (File.Exists("RoomSave.xml"))
                File.Delete("RoomSave.xml");
        }

        /// <summary>
        /// Checks every frame for a new request to save
        /// </summary>
        public void Update(GameTime gameTime, Room roomClass)
        {
            if (roomSaveRequest)
            {
                SaveGame(roomClass);
                roomSaveRequest = false;
            }
            else if (roomLoadRequest)
            {
                LoadGame(roomClass);
                roomLoadRequest = false;
            }
        }
    }
}