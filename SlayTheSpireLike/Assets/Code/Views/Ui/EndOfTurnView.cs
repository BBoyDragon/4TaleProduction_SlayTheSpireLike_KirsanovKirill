using System;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Views.Ui
{
    public class EndOfTurnView: MonoBehaviour
    {
        [SerializeField] private Button _endOfTurnButton;
        public event Action OnEndOfTurnButtonPressed;

        public void SetUp()
        {
            _endOfTurnButton.onClick.AddListener(()=>
            {
                Debug.Log("Тыык");
                OnEndOfTurnButtonPressed?.Invoke();
            });
        }

        public void Cleanup()
        {
            _endOfTurnButton.onClick.RemoveAllListeners();
        }
    }
}