using System;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SlothathorRestart
{
    /// <summary>
    /// Acts as the bridge between the saved XML data and the 
    /// game variables that are going to be saved.
    /// </summary>
    [Serializable()]
    public struct RoomData
    {
        public int roomNumber;
        public Room[] levels;
    }
}