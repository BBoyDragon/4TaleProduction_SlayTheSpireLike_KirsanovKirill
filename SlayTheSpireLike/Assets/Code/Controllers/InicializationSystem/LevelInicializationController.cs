using System.Collections.Generic;
using System.Linq;
using Code.Configs;
using Code.Configs.CardSystemData;
using Code.Controllers.CardSystem;
using Code.Controllers.ControllerUtility;
using Code.Controllers.EnemySystem;
using Code.Controllers.LevelCycleSystem;
using Code.Controllers.LevelCycleSystem.TurnState;
using Code.Controllers.LevelQueueSystem;
using Code.Controllers.LevelSystem;
using Code.Models;
using Code.Models.CardSystem.DeckSystem;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Controllers.InicializationSystem
{
    public class LevelInicializationController : IInicializationController
    {
        private ControllerRunner _controllerRunner;
        private ILevelSpawnController _levelSpawnController;
        private ILevelCycleController _levelCycleController;
        private IEnemyBehaviourController _enemyBehaviourController;
        private ICardPlayingController _cardPlayingController;

        public LevelInicializationController(ControllerRunner controllerRunner)
        {
            _controllerRunner = controllerRunner;
        }

        public void Init()
        {
            LevelModel levelModel = LevelQueueService.Instance.GetCurrentLevel().Create();
            PlayerModel playerModel = Resources.Load<PlayerData>("Configs/PlayerData").Create();
            TurnQueueData turnQueueData = Resources.Load<TurnQueueData>("Configs/Turns/TurnQueueData");
            DeckModel deckModel = Resources.Load<DeckData>("Configs/CardSystem/Deck").Create();
            DeckModel graveyardModel = Resources.Load<DeckData>("Configs/CardSystem/GraveYard").Create();
            HandModel handModel = Resources.Load<HandData>("Configs/CardSystem/Hand").Create();

            _levelSpawnController = new LevelSpawnController(levelModel, playerModel);
            List<EnemyModel> enemyModels = levelModel.EnemySpawnPoints.Select(point => point.Value).ToList();
            _cardPlayingController = new CardPLayingController(deckModel, graveyardModel, handModel, playerModel,enemyModels);
            _controllerRunner.Add(_cardPlayingController);
            _controllerRunner.Add(_levelSpawnController);
            _enemyBehaviourController = new RoundRobinEnemyBehaviourController(enemyModels, playerModel);
            List<ITurnState> turnStates = turnQueueData.TurnStates;
            turnStates.ForEach(state =>
            {
                if (state is INeedEnemyBehaviourController needEnemyBehaviourController)
                {
                    needEnemyBehaviourController.SetEnemyBehaviourController(_enemyBehaviourController);
                }

                if (state is INeedCardPlayingController needCardPlayingController)
                {
                    needCardPlayingController.SetCardPlayingController(_cardPlayingController);
                }
            });
            _levelCycleController = new LevelSycleController(turnStates);
            _controllerRunner.Add(_levelCycleController);
        }
    }
}