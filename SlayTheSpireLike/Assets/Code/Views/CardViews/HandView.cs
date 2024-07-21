using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Views.Ui
{
    public class HandView : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _cardSlots;

        private bool IsEmpty(int index)
        {
            return _cardSlots[index].transform.childCount == 0;
        }

        public void SetCard(CardView cardView)
        {
            for (int i = 0; i < _cardSlots.Count; i++)
            {
                if (IsEmpty(i))
                {
                    Transform transform1;
                    (transform1 = cardView.transform).SetParent(_cardSlots[i].transform);
                    transform1.localPosition = Vector3.zero;
                }
            }
        }

        public void RemoveCard(CardView cardView)
        {
            
            var cardSlot = _cardSlots
                .Where(slot => slot.transform.childCount > 0)
                .Select(slot => slot.transform.GetChild(0).gameObject.GetComponent<CardView>())
                .ToList();
            
            if (cardSlot.Remove(cardView))
            {
                GameObject.Destroy(cardView.gameObject);
            }
        }

        public List<GameObject> CardSlots => _cardSlots;
    }
}