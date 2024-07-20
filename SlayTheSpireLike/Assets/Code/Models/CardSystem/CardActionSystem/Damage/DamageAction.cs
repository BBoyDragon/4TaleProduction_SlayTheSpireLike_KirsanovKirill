using Code.Models.HealthSystem;

namespace Code.Models.CardSystem.CardActionSystem
{
    public class DamageAction: ICardAction, INeedDamagable
    {
        private float _damage;
        private IDamagable _target;

        public DamageAction(float damage)
        {
            _damage = damage;
        }

        public void Execute()
        {
            if (CanBePlayed())
            {
                _target.ReceiveDamage(_damage);
                _target = null;
            }
        }

        public bool CanBePlayed()
        {
            return _target != null;
        }

        public void SetTarget(IDamagable target)
        {
            _target = target;
        }
    }
}