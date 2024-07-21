using Code.Models.HealthSystem;

namespace Code.Models.CardSystem.CardActionSystem.Armor
{
    public class ArmorAction: ICardAction, INeedArmorable
    {
        private int _armor;
        private IArmorable _armorable;

        public ArmorAction(int armor)
        {
            _armor = armor;
        }

        public void Execute()
        {
            if (CanBePlayed())
            {
                _armorable.ArmorUp(_armor);
            }

            _armorable = null;
        }

        public bool CanBePlayed()
        {
            return _armorable != null;
        }

        public void SetTarget(IArmorable target)
        {
            _armorable = target;
        }
    }
}