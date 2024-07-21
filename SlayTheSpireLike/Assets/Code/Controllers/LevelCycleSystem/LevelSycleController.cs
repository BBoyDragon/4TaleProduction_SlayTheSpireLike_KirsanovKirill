using System.Collections.Generic;
using Code.Configs;
using Code.Controllers.EnemySystem;
using Code.Controllers.LevelCycleSystem.TurnState;

namespace Code.Controllers.LevelCycleSystem
{
    public class LevelSycleController: ILevelCycleController
    {
        private ITurnState _currentState;
        private List<ITurnState> _states;
        private int _currentIndex;
        
        public LevelSycleController(List<ITurnState> turnStates)
        {
            _states = turnStates;
            
        }

        public void Start()
        {
            _states.ForEach(states=>states.LevelCycleController=this);
            _currentIndex = 0;
            _currentState = _states[_currentIndex];
            _currentState.Enter();
            
        }

        public void Execute()
        {
            _currentState?.Execute();
        }

        public void ChangeState()
        {
            _currentState?.Exit();
            _currentIndex = (_currentIndex + 1) % _states.Count;
            _currentState = _states[_currentIndex];
            _currentState.Enter();
        }

        public void Clean()
        {
            _states.ForEach(State=>State.Clean());
        }
    }
}