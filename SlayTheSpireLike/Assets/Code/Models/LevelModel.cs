using System.Collections.Generic;
using UnityEngine;

namespace Code.Models
{
    public class LevelModel
    {
        private GameObject _environment;
        private GameObject _playerSpawnPoint;
        private List<KeyValuePair<GameObject,EnemyModel>> _enemySpawnPoints;

        public LevelModel(GameObject environment, GameObject playerSpawnPoint, List<KeyValuePair<GameObject, EnemyModel>> enemySpawnPoints)
        {
            _environment = environment;
            _playerSpawnPoint = playerSpawnPoint;
            _enemySpawnPoints = enemySpawnPoints;
        }

        public GameObject Environment => _environment;

        public GameObject PlayerSpawnPoint => _playerSpawnPoint;

        public List<KeyValuePair<GameObject, EnemyModel>> EnemySpawnPoints => _enemySpawnPoints;
    }
}
