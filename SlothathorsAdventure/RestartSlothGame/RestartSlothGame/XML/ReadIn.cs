using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;

namespace SlothathorRestart
{
    /// <summary>
    /// Pass in and assign values from external XML files
    /// </summary>
    public class ReadIn
    {
        /// <summary>
        /// Reads in set constants through XML
        /// Scans the document looking for the tag name, then assigns
        /// value to static value in other class
        /// </summary>
        public static void RoomPassIn()
        {
            XmlDocument doc = new XmlDocument();
            XmlNodeList nodes;

            doc.Load("RoomConsts.xml");

            nodes = doc.GetElementsByTagName("NumberOfLevels");
            foreach (XmlNode node in nodes)
            {
                Game1.numberOfLevels = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("NumberOfMenus");
            foreach (XmlNode node in nodes)
            {
                Game1.numberOfMenus = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("NumberOfNets");
            foreach (XmlNode node in nodes)
            {
                Game1.netNumber = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("NumberOfJaguars");
            foreach (XmlNode node in nodes)
            {
                Game1.jaguarNumber = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("NumberOfPickups");
            foreach (XmlNode node in nodes)
            {
                Game1.pickupNumber = int.Parse(node.InnerText);
            }
        }

        /// <summary>
        /// Reads in set constants through XML
        /// Scans the document looking for the tag name, then assigns
        /// value to static value in other class
        /// </summary>
        public static void SlothPassIn()
        {
            XmlDocument doc = new XmlDocument();
            XmlNodeList nodes;

            doc.Load("SlothConsts.xml");

            nodes = doc.GetElementsByTagName("InitialAttack");
            foreach (XmlNode node in nodes)
            {
                Sloth.initialAttack = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("InitialExperience");
            foreach (XmlNode node in nodes)
            {
                Sloth.initialExperience = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("InitialHealth");
            foreach (XmlNode node in nodes)
            {
                Sloth.initialHealth = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("XPreviousCoord");
            foreach (XmlNode node in nodes)
            {
                Sloth.xPrevious = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("XStartCoord");
            foreach (XmlNode node in nodes)
            {
                Sloth.xStart = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("YStartCoord");
            foreach (XmlNode node in nodes)
            {
                Sloth.yStart = int.Parse(node.InnerText);
            }
        }

        /// <summary>
        /// Reads in set constants through XML
        /// Scans the document looking for the tag name, then assigns
        /// value to static value in other class
        /// </summary>
        public static void ItemPassIn()
        {
            XmlDocument doc = new XmlDocument();
            XmlNodeList nodes;

            doc.Load("ItemConsts.xml");

            nodes = doc.GetElementsByTagName("FlowerHealth");
            foreach (XmlNode node in nodes)
            {
                Flower.health = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("LeafHealth");
            foreach (XmlNode node in nodes)
            {
                Leaf.health = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("RockExperience");
            foreach (XmlNode node in nodes)
            {
                Rock.experience = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("JaguarAttack");
            foreach (XmlNode node in nodes)
            {
                Jaguar.attack = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("JaguarExperience");
            foreach (XmlNode node in nodes)
            {
                Jaguar.experience = int.Parse(node.InnerText);
            }

            nodes = doc.GetElementsByTagName("JaguarHealth");
            foreach (XmlNode node in nodes)
            {
                Jaguar.health = int.Parse(node.InnerText);
            }
        }
    }
}
