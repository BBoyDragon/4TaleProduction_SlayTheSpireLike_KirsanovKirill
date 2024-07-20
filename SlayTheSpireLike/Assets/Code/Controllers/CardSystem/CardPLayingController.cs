using System.Collections.Generic;
using Code.Models;
using Code.Models.CardSystem;
using Code.Models.CardSystem.CardActionSystem;
using Code.Models.CardSystem.CardActionSystem.Armor;
using Code.Models.CardSystem.CardActionSystem.Heal;
using Code.Models.CardSystem.DeckSystem;

namespace Code.Controllers.CardSystem
{
    public class CardPLayingController: ICardPlayingController
    {
        private DeckModel _deck;
        private DeckModel _graveYard;
        private HandModel _hand;
        private CardModel _chosenCard;

        private PlayerModel _playerModel;
        private List<EnemyModel> _enemyModels;

        public CardPLayingController(DeckModel deck, DeckModel graveYard, HandModel hand, PlayerModel playerModel, List<EnemyModel> enemyModels)
        {
            _deck = deck;
            _graveYard = graveYard;
            _hand = hand;
            _playerModel = playerModel;
            _enemyModels = enemyModels;
            _playerModel.OnPlayerWasChosen += UseCardOnPlayer;
            _enemyModels.ForEach(enemy => enemy.OnEnemyWasChosen += UseCardOnEnenmy);
        }

        private void PeekCard(CardModel cardModel)
        {
            _chosenCard = cardModel;
        }

        private void UseCardOnPlayer(PlayerModel PlayerModel)
        {
            if(_chosenCard==null)
                return;
            bool canBePlayed=true;
            _chosenCard.ScenarioActions[CardPalyingScenario.OnPlay].ForEach(action =>
            {
                if (action is INeedHealable needHealable)
                {
                    needHealable.SetTarget(PlayerModel);
                }

                if (action is INeedArmorable needArmorable)
                {
                    needArmorable.SetTarget(PlayerModel);
                }

                if (!action.CanBePlayed())
                {
                    canBePlayed = false;
                }
            });
            if (!canBePlayed)
            {
                return;
            }
            _chosenCard.ExecuteActions(CardPalyingScenario.OnPlay);
            _hand.RemoveCard(_chosenCard);
            _graveYard.Add(_chosenCard);
            _chosenCard.OnCardWasPicked -= PeekCard;
            _chosenCard = null;
        }

        private void UseCardOnEnenmy(EnemyModel enemyModel)
        {
            if(_chosenCard==null)
                return;
            bool canBePlayed=true;
            _chosenCard.ScenarioActions[CardPalyingScenario.OnPlay].ForEach(action =>
            {
                if (action is INeedDamagable needDamagable)
                {
                    needDamagable.SetTarget(enemyModel);
                }

                if (!action.CanBePlayed())
                {
                    canBePlayed = false;
                }
            });
            if (!canBePlayed)
            {
                return;
            }
            _chosenCard.ExecuteActions(CardPalyingScenario.OnPlay);
            _hand.RemoveCard(_chosenCard);
            _graveYard.Add(_chosenCard);
            _chosenCard = null;
        }


        public void GetNewCards()
        {
            _deck.Shufle();
            int count = 0;
            while (_hand.HandSize<_hand.HandCapacity && count<5)
            {
                if (_deck.Size()==0)
                {
                    while (_graveYard.Size()>0)
                    {
                        _deck.Add(_graveYard.Draw());
                    }
                }

                CardModel card = _deck.Draw();
                card.OnCardWasPicked += PeekCard;
                _hand.TakeCard(card);
                count++;
            }
        }

        public void Activate()
        {
           
        }

        public void Deactivate()
        {
        }

        public void Clean()
        {
            _playerModel.Clean();
            _playerModel.OnPlayerWasChosen -= UseCardOnPlayer;
            _enemyModels.ForEach(enemy => enemy.OnEnemyWasChosen -= UseCardOnEnenmy);
            _hand.CardModels.ForEach(card=>card.OnCardWasPicked-=PeekCard);
        }
    }
}