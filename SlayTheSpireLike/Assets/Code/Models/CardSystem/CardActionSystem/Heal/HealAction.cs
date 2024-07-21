using Code.Models.HealthSystem;

namespace Code.Models.CardSystem.CardActionSystem.Heal
{
    public class HealAction: ICardAction, INeedHealable
    {
        private float _healAmount;
        private IHealable _target;

        public HealAction(float healAmount)
        {
            _healAmount = healAmount;
        }

        public void Execute()
        {
            if (CanBePlayed())
            {
                _target.Heal(_healAmount);
            }
        }

        public bool CanBePlayed()
        {
            return _target != null;
        }

        public void SetTarget(IHealable target)
        {
            _target = target;
        }
    }
}