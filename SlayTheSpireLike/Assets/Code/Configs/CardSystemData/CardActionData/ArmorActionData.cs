using Code.Models.CardSystem.CardActionSystem;
using Code.Models.CardSystem.CardActionSystem.Armor;
using UnityEngine;

namespace Code.Configs.CardSystemData.CardActionData
{
    [CreateAssetMenu(fileName = "ArmorActionData", menuName = "CardSystem/ArmorActionData")]
    public class ArmorActionData: CardActionData
    {
        [SerializeField] private int _armor;
        public override ICardAction Create()
        {
            return new ArmorAction(_armor);
        }
    }
}