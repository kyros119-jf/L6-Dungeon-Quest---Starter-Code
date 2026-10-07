using FinalBattler.Character.Upgrades;
using FinalBattler.Interfaces;

namespace FinalBattler.Character
{
    public class Hero : Creations, IHero

    {
        public int Health { get; set; }
        public int Power { get; set; }
        public int Luck { get; set; }
        public int Mana { get; set; }
        public int ExperienceRemaining { get; set; }
        public CombatClass CombatClass { get; set; }
        public List<Item> Items { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Spell> Spells { get; set; }
        public List<Equipment> Equipment { get; set; }



        public Hero()
        {
            Name = "Unknown";
            Level = 0;
            Health = 1;
            Power = 1;
            Luck = 1;
            Mana = 1;

            Items = new List<Item>();
            Skills = new List<Skill>();
            Spells = new List<Spell>();
            Equipment = new List<Equipment>();
        }
        public void LevelUp()
        {
            Random random = new Random();
            switch (CombatClass)
            {
                case CombatClass.Warrior:
                    Health += random.Next(10, 21);
                    Power += random.Next(1, 4);
                    Luck += random.Next(1, 4);
                    break;
                case CombatClass.Wizard:
                    Health += random.Next(1, 16);
                    Power += random.Next(3, 6);
                    Luck += random.Next(1, 4);
                    break;
                case CombatClass.Rogue:
                    Health += random.Next(1, 16);
                    Power += random.Next(1, 4);
                    Luck += random.Next(3, 6);
                    break;
                default:
                    break;
            }

        }
        public void CalculateTotals()
        {
            TotalHealth = Health;
            TotalPower = Power;
            TotalLuck = Luck;
            foreach (Equipment equipment in Equipment)
            {
                switch (equipment.StatBoostType)
                {
                    case StatBoostType.Health:
                        TotalHealth += equipment.BoostValue;
                        break;
                    case StatBoostType.Power:
                        TotalPower += equipment.BoostValue;
                        break;
                    case StatBoostType.Luck:
                        TotalLuck += equipment.BoostValue;
                        break;
                    default:
                        break;
                }
            }
        }
        public void DisplayStats(bool showTotalStats = false)
        {
            if (showTotalStats)
            {
                CalculateTotals();

                Console.WriteLine($"Name: {Name}, Level: {Level}, Total Health: {TotalHealth}, Total Power: {TotalPower}, Total Luck: {TotalLuck}");
            }
            else
            {
                Console.WriteLine($"Name: {Name}, Level: {Level}, Health: {Health}, Power: {Power}, Luck: {Luck}");
            }
        }
    }
}