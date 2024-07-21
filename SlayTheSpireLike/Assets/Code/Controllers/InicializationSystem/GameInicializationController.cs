using Code.Configs;
using Code.Controllers.ControllerUtility;
using Code.Controllers.LevelQueueSystem;
using UnityEngine;

namespace Code.Controllers.InicializationSystem
{
    public class GameInicializationController : IInicializationController
    {
        private ControllerRunner _controllerRunner;
        private ILevelQueueController _levelQueueController;

        public GameInicializationController(ControllerRunner controllerRunner)
        {
            _controllerRunner = controllerRunner;
        }
        public void Init()
        {
            _levelQueueController = new LevelQueueController(Resources.Load<LevelQueueData>("Configs/levels/LevelQueueData"));
            _controllerRunner.Add(_levelQueueController);
        }
    }
}