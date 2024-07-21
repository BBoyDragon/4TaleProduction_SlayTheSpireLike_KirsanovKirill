using Code.Controllers.LevelCycleSystem.TurnState;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "TurnData", menuName = "TurnData/TurnData")]
    public abstract class TurnData : ScriptableObject
    {
        public abstract ITurnState Create();
    }
}