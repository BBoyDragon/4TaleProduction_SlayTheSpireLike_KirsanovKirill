using System;
using UnityEngine;

namespace Code.Views
{
    public class PlayerView: MonoBehaviour
    {
        [SerializeField] private GameObject _healthPosition;
        public event Action OnMouseClick;

        public GameObject HealthPosition => _healthPosition;

        private void OnMouseDown()
        {
            OnMouseClick?.Invoke();
        }
    }
}