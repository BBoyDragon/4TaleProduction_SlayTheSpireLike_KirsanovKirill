using Code.Controllers.LevelCycleSystem.TurnState;
using Code.Views.Ui;
using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "PlayerTurnData", menuName = "TurnData/PlayerTurnData")]
    public class PlayerTurnData: TurnData
    {
        [SerializeField] private EndOfTurnView _endOfTurnView;
        public override ITurnState Create()
        {
            return new PlayerTurnState(_endOfTurnView);
        }
    }
}