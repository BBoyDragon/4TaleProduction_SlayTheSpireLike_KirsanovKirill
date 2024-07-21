using Code.Models.CardSystem.CardActionSystem;
using UnityEngine;

namespace Code.Configs.CardSystemData.CardActionData
{
    [CreateAssetMenu(fileName = "CardActionData", menuName = "CardSystem/CardActionData")]
    public abstract class CardActionData: ScriptableObject
    {
        public abstract ICardAction Create();
    }
}