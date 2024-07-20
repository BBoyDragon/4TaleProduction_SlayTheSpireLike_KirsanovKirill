using Code.Models;
using Code.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Configs
{
    
    public abstract class EnemyData : ScriptableObject
    { 
        [SerializeField]
        protected EnemyView enemyView;

        public abstract EnemyModel Create();
    }
}