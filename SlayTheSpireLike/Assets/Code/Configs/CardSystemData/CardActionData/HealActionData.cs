using Code.Models.CardSystem.CardActionSystem;
using Code.Models.CardSystem.CardActionSystem.Heal;
using UnityEngine;

namespace Code.Configs.CardSystemData.CardActionData
{
    [CreateAssetMenu(fileName = "HealActionData", menuName = "CardSystem/HealActionData")]
    public class HealActionData: CardActionData
    {
        [SerializeField] private float _heal;
        public override ICardAction Create()
        {
            return new HealAction(_heal);
        }
    }
}