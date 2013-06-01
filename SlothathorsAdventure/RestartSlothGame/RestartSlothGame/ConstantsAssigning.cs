using System;

namespace SlothathorRestart
{
    /// <summary>
    /// Called if the ReadIn fails, assigns constants to values throughout game
    /// </summary>
    public struct ConstantsAssigning
    {
        /// <summary>
        /// Assigns constants to values throughout game
        /// </summary>
        public void Assign()
        {
            Game1.numberOfLevels = Game1.NUMBER_OF_LEVELS;
            Game1.numberOfMenus = Game1.NUMBER_OF_MENUS;
            Game1.netNumber = Game1.NET_NUMBER;
            Game1.jaguarNumber = Game1.JAGUAR_NUMBER;
            Game1.pickupNumber = Game1.PICKUP_NUMBER;

            Sloth.initialAttack = Sloth.INITIAL_ATTACK;
            Sloth.initialExperience = Sloth.INITIAL_EXPERIENCE;
            Sloth.initialHealth = Sloth.INITIAL_HEALTH;
            Sloth.xPrevious = Sloth.X_PREVIOUS;
            Sloth.xStart = Sloth.X_START;
            Sloth.yStart = Sloth.Y_START;

            Flower.health = Flower.HEALTH;
            Leaf.health = Leaf.HEALTH;
            Rock.experience = Rock.EXPERIENCE;
            Jaguar.attack = Jaguar.ATTACK;
            Jaguar.experience = Jaguar.EXPERIENCE;
            Jaguar.health = Jaguar.HEALTH;
        }
    }
}
