using System;
using System.Collections.Generic;
using Code.Models.CardSystem;
using Code.Models.HealthSystem;
using Code.Views;
using UnityEngine;

namespace Code.Models
{
    public class EnemyModel: IClean,IHealable, IDamagable
    {
        private EnemyView _enemyView;
        private HealthModel _healthModel;
        private float _maxHp;
        public event Action<EnemyModel> OnEnemyWasChosen;

        public EnemyModel(EnemyView enemyView, float maxHp)
        {
            _enemyView = enemyView;
            _maxHp = maxHp;
        }

        public EnemyView View
        {
            get => _enemyView;
            set => _enemyView = value;
        }

        public void Setup()
        {
            _enemyView.OnMouseClick += Peek;
            _healthModel = new HealthModel(_maxHp, _enemyView.HealthPosition);
            _healthModel.OnDied += Deactivate;
        }

        private void Deactivate()
        {
            Clean();
            GameObject.Destroy(_enemyView.gameObject);
        }
        
        private void Peek()
        {
            OnEnemyWasChosen?.Invoke(this);
        }
        
        public void Clean()
        {
            _enemyView.OnMouseClick -= Peek;
            _healthModel.OnDied -= Deactivate;
        }

        public void Heal(float amount)
        {
            _healthModel.Heal(amount);
        }

        public void ReceiveDamage(float amount)
        {
            _healthModel.TakeDamage(amount);
        }
    }
}
