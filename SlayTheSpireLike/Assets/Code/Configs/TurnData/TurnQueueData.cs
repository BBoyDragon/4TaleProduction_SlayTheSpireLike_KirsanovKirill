using System.Collections.Generic;
using System.Linq;
using Code.Controllers.LevelCycleSystem.TurnState;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "TurnQueueData", menuName = "TurnData/TurnQueueData")]
    public class TurnQueueData: ScriptableObject
    {
        [SerializeField] private List<TurnData> _turnDatas;

        public List<ITurnState> TurnStates => _turnDatas.Select(data => data.Create()).ToList();
    }
}