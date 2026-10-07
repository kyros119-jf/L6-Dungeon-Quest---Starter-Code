
using FinalBattler.Character;

public class Program
{

    static void Main()
    {

        Hero hero = new Hero();

        hero.CombatClass = CombatClass.Wizard;

        hero.LevelUp();

        hero.DisplayStats(true);
    }
}


