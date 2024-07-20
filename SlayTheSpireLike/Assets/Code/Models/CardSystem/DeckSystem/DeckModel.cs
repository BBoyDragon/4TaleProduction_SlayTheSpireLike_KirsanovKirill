using System.Collections.Generic;
using Code.Views.CardViews;
using UnityEngine;

namespace Code.Models.CardSystem.DeckSystem
{
    public class DeckModel
    {
        private Queue<CardModel> _cards;
        private DeckView _deckView;

        public DeckModel(List<CardModel> cards, DeckView deckView)
        {
            _deckView = GameObject.Instantiate(deckView);
            _cards = new Queue<CardModel>(cards);
        }
        public int Size() => _cards.Count;
        public CardModel Draw()
        {
            return _cards.Dequeue();
        }
        public void Add(CardModel cardModel)
        {
            _cards.Enqueue(cardModel);
        }

        public void Shufle()
        {
            List<CardModel> list = new List<CardModel>(_cards);
            _cards.Clear();
            
            System.Random random = new System.Random();
            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }
            
            foreach (var item in list)
            {
                _cards.Enqueue(item);
            }
        }
    }
}