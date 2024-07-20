using Code.Models;
using Code.Utility.ControllerMethods;
using Unity.Mathematics;
using UnityEngine;

namespace Code.Controllers.LevelSystem
{
    public class LevelSpawnController : ILevelSpawnController
    {
        private LevelModel _levelModel;
        private PlayerModel _playerModel;

        public LevelSpawnController(LevelModel levelModel, PlayerModel playerModel)
        {
            _levelModel = levelModel;
            _playerModel = playerModel;
        }

        public void Awake()
        {
            GameObject.Instantiate(_levelModel.Environment);
            _levelModel.EnemySpawnPoints.ForEach(point=>
            {
                point.Value.View = GameObject.Instantiate(
                    point.Value.View,
                    point.Key.transform.position,
                    point.Value.View.transform.rotation);
                point.Value.Setup();
            });
            _playerModel.View = GameObject.Instantiate(_playerModel.View, _levelModel.PlayerSpawnPoint.transform.position, quaternion.identity);
            _playerModel.Setup();
        }
    }
}
