using System.Collections.Generic;
using System.Linq;
using Code.Configs.CardSystemData;
using Code.Models;
using Code.Models.CardSystem;
using Code.Views;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "RandomCardEnemyData", menuName = "Enenmy/RandomCardEnemyData")]
    public class RandomCardEnemyData : EnemyData
    {
        [SerializeField] private List<CardModelData> cardFactories;
        [SerializeField] private int _maxHp;
        public override EnemyModel Create()
        {
            List<CardModel> cards = cardFactories.Select(card => card.Create()).ToList();

            RandomCardEnemyModel enemy = new RandomCardEnemyModel(enemyView, cards, _maxHp);
            return enemy;
        }
    }
}