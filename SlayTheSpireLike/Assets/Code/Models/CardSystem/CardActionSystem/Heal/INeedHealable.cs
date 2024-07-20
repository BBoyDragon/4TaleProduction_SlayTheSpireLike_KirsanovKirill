using Code.Models.HealthSystem;

namespace Code.Models.CardSystem.CardActionSystem.Heal
{
    public interface INeedHealable
    {
        public void SetTarget(IHealable target);
    }
}