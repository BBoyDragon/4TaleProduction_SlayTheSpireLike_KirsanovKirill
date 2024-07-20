using System;
using Code.Controllers.CardSystem;
using Code.Views.Ui;
using UnityEngine;

namespace Code.Controllers.LevelCycleSystem.TurnState
{
    public class PlayerTurnState: ITurnState, INeedCardPlayingController
    {
        private ILevelCycleController _levelCycleController;
        private EndOfTurnView _endOfTurnView;
        private ICardPlayingController _cardPlayingController;

        public PlayerTurnState(EndOfTurnView endOfTurnView)
        {
            _endOfTurnView = GameObject.Instantiate<EndOfTurnView>(endOfTurnView);
            _endOfTurnView.SetUp();
            _endOfTurnView.gameObject.SetActive(false);
            OnEnter?.Invoke();
        }

        public event Action OnEnter;
        public event Action OnExit;

        public void Enter()
        {
            _endOfTurnView.gameObject.SetActive(true);
            _endOfTurnView.OnEndOfTurnButtonPressed += _levelCycleController.ChangeState;
            _cardPlayingController.GetNewCards();
            _cardPlayingController.Activate();
        }

        public void Execute()
        {
        }

        public void Exit()
        {
            _endOfTurnView.gameObject.SetActive(false);
            _endOfTurnView.OnEndOfTurnButtonPressed -= _levelCycleController.ChangeState;
            _cardPlayingController.Deactivate();
            OnExit?.Invoke();
        }
        
        public ILevelCycleController LevelCycleController
        {
            get => _levelCycleController;
            set => _levelCycleController = value;
        }

        public void SetCardPlayingController(ICardPlayingController cardPLayingController)
        {
            _cardPlayingController = cardPLayingController;
        }

        public void Clean()
        {
            _endOfTurnView.OnEndOfTurnButtonPressed -= _levelCycleController.ChangeState;
        }
    }
}