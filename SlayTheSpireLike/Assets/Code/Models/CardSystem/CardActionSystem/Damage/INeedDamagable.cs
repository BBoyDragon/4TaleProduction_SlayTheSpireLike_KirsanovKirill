using Code.Models.HealthSystem;

namespace Code.Models.CardSystem.CardActionSystem
{
    public interface INeedDamagable
    {
        public void SetTarget(IDamagable target);
    }
}