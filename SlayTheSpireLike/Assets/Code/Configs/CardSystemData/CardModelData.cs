using System;
using System.Collections.Generic;
using System.Linq;
using Code.Models.CardSystem;
using Code.Models.CardSystem.CardActionSystem;
using Code.Views;
using UnityEngine;

namespace Code.Configs.CardSystemData
{
    [CreateAssetMenu(fileName = "CardModelData", menuName = "CardSystem/CardModelData")]
    public class CardModelData: ScriptableObject
    {
        [SerializeField] private CardView _cardView;
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _sprite;
        [Serializable]
        public struct ScenarioAction
        {
            public CardPalyingScenario scenario;
            public CardActionData.CardActionData action;
        }

        [SerializeField] private List<ScenarioAction> _scenarioActions;

        public CardModel Create()
        {
            CardModel cardModel = new CardModel(_cardView, _name, _description, _sprite);
            _scenarioActions.ForEach(scenarioAction =>
                cardModel.AddAction(scenarioAction.scenario, scenarioAction.action.Create()));
            return cardModel;
        }
    }
}