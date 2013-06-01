using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;

namespace SlothathorRestart
{
    /// <summary>
    /// Writing out Room, Sloth, Jaguar and Item Constants with XML
    /// </summary>
    public class WriteOutConsts
    {
        /// <summary>
        /// All of the room constants contained in the Game1 class
        /// </summary>
        public void RoomConsts()
        {
            using (XmlWriter writer = XmlWriter.Create("RoomConsts.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("RoomConstants");
                writer.WriteStartElement("NumberOfLevels");
                writer.WriteValue(Game1.NUMBER_OF_LEVELS);
                writer.WriteEndElement();
                writer.WriteStartElement("NumberOfMenus");
                writer.WriteValue(Game1.NUMBER_OF_MENUS);
                writer.WriteEndElement();
                writer.WriteStartElement("NumberOfNets");
                writer.WriteValue(Game1.NET_NUMBER);
                writer.WriteEndElement();
                writer.WriteStartElement("NumberOfJaguars");
                writer.WriteValue(Game1.JAGUAR_NUMBER);
                writer.WriteEndElement();
                writer.WriteStartElement("NumberOfPickups");
                writer.WriteValue(Game1.PICKUP_NUMBER);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// All sloth constants contained in the sloth class
        /// </summary>
        public void SlothConsts()
        {
            using (XmlWriter writer = XmlWriter.Create("SlothConsts.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("SlothConstants");
                writer.WriteStartElement("InitialAttack");
                writer.WriteValue(Sloth.INITIAL_ATTACK);
                writer.WriteEndElement();
                writer.WriteStartElement("InitialExperience");
                writer.WriteValue(Sloth.INITIAL_EXPERIENCE);
                writer.WriteEndElement();
                writer.WriteStartElement("InitialHealth");
                writer.WriteValue(Sloth.INITIAL_HEALTH);
                writer.WriteEndElement();
                writer.WriteStartElement("XPreviousCoord");
                writer.WriteValue(Sloth.X_PREVIOUS);
                writer.WriteEndElement();
                writer.WriteStartElement("XStartCoord");
                writer.WriteValue(Sloth.X_START);
                writer.WriteEndElement();
                writer.WriteStartElement("YStartCoord");
                writer.WriteValue(Sloth.Y_START);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
        /// <summary>
        /// All the Item and Jaguar constants
        /// </summary>
        public void ItemConsts()
        {
            using (XmlWriter writer = XmlWriter.Create("ItemConsts.xml"))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ItemsAndJaguarConstants");
                writer.WriteStartElement("FlowerHealth");
                writer.WriteValue(Flower.HEALTH);
                writer.WriteEndElement();
                writer.WriteStartElement("LeafHealth");
                writer.WriteValue(Leaf.HEALTH);
                writer.WriteEndElement();
                writer.WriteStartElement("RockExperience");
                writer.WriteValue(Rock.EXPERIENCE);
                writer.WriteEndElement();
                writer.WriteStartElement("JaguarAttack");
                writer.WriteValue(Jaguar.ATTACK);
                writer.WriteEndElement();
                writer.WriteStartElement("JaguarExperience");
                writer.WriteValue(Jaguar.EXPERIENCE);
                writer.WriteEndElement();
                writer.WriteStartElement("JaguarHealth");
                writer.WriteValue(Jaguar.HEALTH);
                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}







