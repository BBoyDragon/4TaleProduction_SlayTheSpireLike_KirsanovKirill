using System.Collections.Generic;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "LevelQueueData", menuName = "LevelQueueData")]
    public class LevelQueueData: ScriptableObject
    {
        [SerializeField]
        private List<LevelData> levelDatas;

        public List<LevelData> LevelDatas => levelDatas;
    }
}