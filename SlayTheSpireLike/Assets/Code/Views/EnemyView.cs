using System;
using UnityEngine;

namespace Code.Views
{
    public class EnemyView: MonoBehaviour
    {
        public event Action OnMouseClick;
        [SerializeField] private GameObject _healthPosition;

        public GameObject HealthPosition => _healthPosition;

        private void OnMouseDown()
        {
            OnMouseClick?.Invoke();
        }
    }
}