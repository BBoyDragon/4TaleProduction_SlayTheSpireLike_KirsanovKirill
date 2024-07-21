using System;

namespace Code.Controllers.LevelCycleSystem.TurnState
{
    public interface ITurnState: IClean
    {
        public event Action OnEnter;
        public event Action OnExit;
        void Enter();
        void Execute();
        void Exit();
        public ILevelCycleController LevelCycleController { get; set; }
    }
}