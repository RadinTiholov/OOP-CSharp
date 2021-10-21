using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        public HealthPotion():base(5)
        {

        }
        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health += 20;
                if (character.Health >= character.BaseHealth)
                {
                    character.Health = character.BaseHealth;
                }
            }
        }
    }
}
