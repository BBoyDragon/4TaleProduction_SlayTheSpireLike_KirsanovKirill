using System;
using System.Collections.Generic;
using System.Linq;
using Code.Views.Ui;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Models.CardSystem.DeckSystem
{
    public class HandModel: IClean
    {
        private HandView _view;
        private List<CardModel> _cardModels;
        public event Action<CardModel> OnCardWasPeeked;

        public int HandCapacity => _view.CardSlots.Count;
        public int HandSize => _cardModels.Count;

        public List<CardModel> CardModels => _cardModels;

        public void TakeCard(CardModel cardModel)
        {
            _cardModels.Add(cardModel);
            cardModel.SpawnView();
            _view.SetCard(cardModel.View);
            _cardModels.Last().OnCardWasPicked += PeekCard;
        }

        public void RemoveCard(CardModel cardModel)
        {
            if (_cardModels.Remove(cardModel))
            {
                cardModel.Clean();
                _view.RemoveCard(cardModel.View);
            }
        }

        private void PeekCard(CardModel cardModel)
        {
            _cardModels.ForEach(card =>
            {
                if (card != cardModel)
                {
                    card.View.SetNormalView();
                }
            });
            OnCardWasPeeked?.Invoke(cardModel);
        }

        public HandModel(HandView view)
        {
            _cardModels = new List<CardModel>();
            _view = GameObject.Instantiate(view);
        }


        public void Clean()
        {
            _cardModels.Last().OnCardWasPicked -= PeekCard;
        }
    }
}