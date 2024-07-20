using Code.Configs;
using UnityEngine.SceneManagement;

namespace Code.Controllers.LevelQueueSystem
{
    public class LevelQueueController: ILevelQueueController
    {
        private LevelQueueData _levelQueueData;
        private LevelQueueService _levelQueueService;

        public LevelQueueController(LevelQueueData levelQueueData)
        {
            _levelQueueData = levelQueueData;
        }

        public void Awake()
        {
            _levelQueueService = LevelQueueService.Instance;
            if (_levelQueueService != null)
            {
                _levelQueueService.SetLevels(_levelQueueData.LevelDatas);
            }
        }

        public void Start()
        {
            SceneManager.LoadScene(1);
        }
    }
}