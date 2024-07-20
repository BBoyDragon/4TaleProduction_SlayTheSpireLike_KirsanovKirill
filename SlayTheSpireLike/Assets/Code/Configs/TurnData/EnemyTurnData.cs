using Code.Controllers.EnemySystem;
using Code.Controllers.LevelCycleSystem.TurnState;
using Code.Views;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "EnemyTurnData", menuName = "TurnData/EnemyTurnData")]
    public class EnemyTurnData: TurnData, IClean
    {
        [SerializeField] private EnemyTurnView _enemyTurnView;
        public override ITurnState Create()
        {
            return new EnemyTurnState(_enemyTurnView);
        }

        public void Clean()
        {
        }
    }
}