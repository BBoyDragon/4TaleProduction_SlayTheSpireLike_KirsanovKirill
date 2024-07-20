using System;
using System.Collections.Generic;
using Code.Models.CardSystem.CardActionSystem;
using Code.Views;
using UnityEngine;

namespace Code.Models.CardSystem
{
    public class CardModel: IClean
    {
        private readonly Dictionary<CardPalyingScenario, List<ICardAction>> _scenarioActions;
        private CardView _cardView;
        private string _name;
        private string _description;
        private Sprite _sprite;

        private CardView _viewPrefab;

        public event Action<CardModel> OnCardWasPicked;

        public CardModel(CardView cardView, string name, string description, Sprite sprite)
        {
            _viewPrefab = cardView;
            _name = name;
            _description = description;
            _sprite = sprite;
            _scenarioActions = new Dictionary<CardPalyingScenario, List<ICardAction>>();
        }

        private void Peek()
        {
            _cardView.SetPickedView();
            OnCardWasPicked?.Invoke(this);
        }
        public void SpawnView()
        {
            _cardView = GameObject.Instantiate(_viewPrefab);
            _cardView.Name.text = _name;
            _cardView.SpriteRenderer1.sprite = _sprite;
            _cardView.Description.text = _description;
            _cardView.OnCardWasClicked += Peek;
        }
        

        public Dictionary<CardPalyingScenario, List<ICardAction>> ScenarioActions => _scenarioActions;

        public CardView View => _cardView;

        public void AddAction(CardPalyingScenario scenario, ICardAction action)
        {
            if (!_scenarioActions.ContainsKey(scenario))
            {
                _scenarioActions[scenario] = new List<ICardAction>();
            }

            _scenarioActions[scenario].Add(action);
        }

        public void ExecuteActions(CardPalyingScenario scenario)
        {
            if (_scenarioActions.TryGetValue(scenario, out var scenarioAction))
            {
                foreach (var action in scenarioAction)
                {
                    action.Execute();
                }
            }
        }

        public void Clean()
        {
            _cardView.OnCardWasClicked -= Peek;
        }
    }
}