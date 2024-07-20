using System.Collections.Generic;
using System.Linq;
using Code.Models;
using Code.Models.CardSystem;
using Code.Models.CardSystem.DeckSystem;
using Code.Views.CardViews;
using UnityEngine;

namespace Code.Configs.CardSystemData
{
    [CreateAssetMenu(fileName = "DeckData", menuName = "CardSystem/DeckData")]
    public class DeckData: ScriptableObject
    {
        [SerializeField] private List<CardModelData> cardFactories;

        [SerializeField] private DeckView deckView;

        public DeckModel Create()
        {
            List<CardModel> cards = cardFactories.Select(card => card.Create()).ToList();
            return new DeckModel(cards, deckView);
        }
    }
}