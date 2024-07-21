using System;
using Code.Controllers.LevelQueueSystem;
using Code.Models.HealthSystem;
using Code.Views;
using Code.Views.Ui;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Models
{
    public class PlayerModel: IDamagable, IHealable, IArmorable, IClean
    {
        private PlayerView _playerView;
        private readonly float _maxHealth;
        private HealthModel _healthModel;
        private float _armor;
        public event Action<PlayerModel> OnPlayerWasChosen;

        public PlayerModel(PlayerView playerView, float maxHealth)
        {
            _playerView = playerView;
            _maxHealth = maxHealth;
        }

        public void Setup()
        {
            _playerView.OnMouseClick += Peek;
            _healthModel = new HealthModel(_maxHealth, _playerView.HealthPosition);
            _healthModel.OnDied += Deactivate;
        }

        public PlayerView View
        {
            get => _playerView;
            set => _playerView = value;
        }

        private void Deactivate()
        {
            Clean();
            LevelQueueService.Instance.ResetService();
            SceneManager.LoadScene(0);
        }
        private void Peek()
        {
            OnPlayerWasChosen?.Invoke(this);
        }
        
        public void ReceiveDamage(float amount)
        {
            _healthModel.TakeDamage(amount);
        }

        public void Heal(float amount)
        {
            _healthModel.Heal(amount);
        }

        public void ArmorUp(int amount)
        {
            _healthModel.ArmorUp(amount);
        }

        public void Clean()
        {
            _playerView.OnMouseClick -= Peek;
            _healthModel.OnDied -= Deactivate;
        }
    }
}