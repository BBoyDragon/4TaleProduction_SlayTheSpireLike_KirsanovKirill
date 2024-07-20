using Code.Models.CardSystem.CardActionSystem;
using UnityEngine;

namespace Code.Configs.CardSystemData.CardActionData
{
    [CreateAssetMenu(fileName = "DamageActionData", menuName = "CardSystem/DamageActionData")]
    public class DamageActionData: CardActionData
    {
        [SerializeField] private float _damage;
        public override ICardAction Create()
        {
            return new DamageAction(_damage);
        }
    }
}