using System.Collections.Generic;
using Code.Models;

namespace Code.Controllers.LevelQueueSystem
{
    public class LevelQueueService
    {
        private static LevelQueueService _instance;
        private List<LevelData> _levels;
        private int _currentLevelIndex = 0;
        
        public static LevelQueueService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LevelQueueService();
                }
                return _instance;
            }
        }

        public List<LevelData> Levels => _levels;

        public int CurrentLevelIndex => _currentLevelIndex;
        

        public void SetLevels(List<LevelData> levels)
        {
            _levels = levels;
        }

        public LevelData GetCurrentLevel()
        {
            if (_levels == null || _levels.Count == 0)
                return null;

            return _levels[_currentLevelIndex];
        }

        public void GoToNextLevel()
        {
            if (_levels == null || _levels.Count == 0)
                return;

            _currentLevelIndex = (_currentLevelIndex + 1) % _levels.Count;
        }
        public void ResetService()
        {
            _levels = null;
            _currentLevelIndex = 0;
            _instance = null;
        }
    }
}