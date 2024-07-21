using System;
using System.Collections.Generic;
using Code.Configs;
using Code.Controllers.EnemySystem;
using Code.Controllers.LevelQueueSystem;
using Code.Models;
using Code.Views;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Controllers.LevelCycleSystem.TurnState
{
    public class EnemyTurnState: ITurnState, INeedEnemyBehaviourController
    {
        private ILevelCycleController _levelCycleController;
        private IEnemyBehaviourController _enemyBehaviourController;
        private EnemyTurnView _enemyTurnView;

        public EnemyTurnState(EnemyTurnView enemyTurnView)
        {
            _enemyTurnView = GameObject.Instantiate(enemyTurnView);
        }

        public event Action OnEnter;
        public event Action OnExit;

        public void Enter()
        {
            OnEnter?.Invoke();
            _enemyBehaviourController.OnEnemyActionIsFinished += _levelCycleController.ChangeState;
            if (!_enemyBehaviourController.CanAct())
            {
                LevelQueueService.Instance.GoToNextLevel();
                SceneManager.LoadScene(1);
            }
            _enemyTurnView.StartCoroutine(_enemyBehaviourController.EnenmyAct());
        }

        public void Execute()
        {
        }

        public void Exit()
        {
            _enemyBehaviourController.OnEnemyActionIsFinished -= _levelCycleController.ChangeState;
            OnExit?.Invoke();
        }
        public ILevelCycleController LevelCycleController
        {
            get => _levelCycleController;
            set => _levelCycleController = value;
        }

        public void SetEnemyBehaviourController(IEnemyBehaviourController enemyBehaviourController)
        {
            _enemyBehaviourController = enemyBehaviourController;
        }

        public void Clean()
        {
            _enemyBehaviourController.OnEnemyActionIsFinished -= _levelCycleController.ChangeState;
        }
    }
}