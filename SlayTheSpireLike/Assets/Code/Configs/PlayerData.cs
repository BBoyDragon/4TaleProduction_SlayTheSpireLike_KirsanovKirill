using Code.Models;
using Code.Views;
using Code.Views.Ui;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        
        public PlayerView playerView;
        [SerializeField] private int _maxHealth;
        
        public PlayerModel Create()
        {
            return new PlayerModel(playerView, _maxHealth);
        }
    }
}