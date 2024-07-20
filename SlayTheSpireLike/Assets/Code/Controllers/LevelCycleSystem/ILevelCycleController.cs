using Code.Controllers.LevelCycleSystem.TurnState;
using Code.Utility.ControllerMethods;

namespace Code.Controllers.LevelCycleSystem
{
    public interface ILevelCycleController : IStart, IExecute, IClean
    {
        public void ChangeState();
    }
}