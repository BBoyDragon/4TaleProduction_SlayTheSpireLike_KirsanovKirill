using System;
using System.Collections;
using System.Collections.Generic;
using Code.Models.CardSystem;
using Code.Models.CardSystem.CardActionSystem;
using Code.Models.CardSystem.CardActionSystem.Armor;
using Code.Models.CardSystem.CardActionSystem.Heal;
using Code.Models.HealthSystem;
using Code.Views;
using UnityEngine;

namespace Code.Models
{
    public class RandomCardEnemyModel: EnemyModel, IPlayCard, INeedPlayer
    {
        private List<CardModel> _cards;
        private PlayerModel _player;
        public RandomCardEnemyModel(EnemyView enemyView, List<CardModel> cards, int maxHp) : base(enemyView, maxHp)
        {
            _cards = cards;
        }

        public IEnumerator Play()
        {
            System.Random random = new System.Random();
            CardModel cardModel = _cards[random.Next(_cards.Count)];
            cardModel.ScenarioActions[CardPalyingScenario.OnPlay].ForEach(action =>
            {
                if (action is INeedDamagable needDamagable)
                {
                    needDamagable.SetTarget(_player);
                }

                if (action is INeedHealable needHealable)
                {
                    needHealable.SetTarget(this);
                }
            });
            cardModel.ExecuteActions(CardPalyingScenario.OnPlay);
            yield return new WaitForSeconds(3);
        }

        public void SetPlayer(PlayerModel playerModel)
        {
            _player = playerModel;
        }
    }
}