using Code.Models.CardSystem.DeckSystem;
using Code.Views.Ui;
using UnityEngine;

namespace Code.Configs.CardSystemData
{
    [CreateAssetMenu(fileName = "HandData", menuName = "CardSystem/HandData")]
    public class HandData: ScriptableObject
    {
        [SerializeField] private HandView _handView;

        public HandModel Create()
        {
            return new HandModel(_handView);
        }
    }
}