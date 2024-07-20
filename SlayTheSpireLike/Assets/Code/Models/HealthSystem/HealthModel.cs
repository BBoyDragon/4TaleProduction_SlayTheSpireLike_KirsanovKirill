using System;
using Code.Views.Ui;
using UnityEngine;

namespace Code.Models.HealthSystem
{
    public class HealthModel
    {
        private float _maxHealth;
        private float _curentHealth;
        private int _armor;
        private HealthView _healthView;
        public event Action OnDied;

        public HealthModel(float maxHealth, GameObject _healthViewPosition)
        {
            _maxHealth = maxHealth;
            _curentHealth = maxHealth;
            _healthView = GameObject.Instantiate(Resources.Load<HealthView>("prefabs/health"),
                _healthViewPosition.transform);
            _healthView.UpdateUi(_maxHealth,_curentHealth, _armor);
        }

        public void TakeDamage(float damage)
        {
            if (damage < 0)
            {
                throw new ArgumentException("Damage below 0");
            }

            if (_armor >= damage)
            {
                _armor -= Convert.ToInt32(damage);
                _healthView.UpdateUi(_maxHealth,_curentHealth, _armor);
                return;
            }

            damage -= _armor;
            _armor = 0;
            if (_curentHealth - damage <= 0)
            {
                _curentHealth = 0;
                OnDied?.Invoke();
            }
            _curentHealth -= damage;
            _healthView.UpdateUi(_maxHealth,_curentHealth, _armor);
        }

        public void Heal(float heal)
        {
            if (heal < 0)
            {
                throw new ArgumentException("Heal below 0");
            }

            if (_curentHealth + heal > _maxHealth)
            {
                _curentHealth = _maxHealth;
                _healthView.UpdateUi(_maxHealth,_curentHealth, _armor);
                return;
            }

            _curentHealth += heal;
            _healthView.UpdateUi(_maxHealth,_curentHealth, _armor);
        }

        public void ArmorUp(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("ArmorUp below 0");
            }
            _armor += amount;
            _healthView.UpdateUi(_maxHealth,_curentHealth, _armor);
        }
    }
}