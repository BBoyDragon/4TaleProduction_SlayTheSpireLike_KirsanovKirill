using System;
using System.Collections;
using System.Collections.Generic;
using Code.Models;
using Unity.VisualScripting;

namespace Code.Controllers.EnemySystem
{
    public class RoundRobinEnemyBehaviourController : IEnemyBehaviourController
    {
        private List<EnemyModel> _enemyModels;

        public RoundRobinEnemyBehaviourController(List<EnemyModel> enemyModels, PlayerModel playerModel)
        {
            _enemyModels = enemyModels;
            _enemyModels.ForEach(model =>
            {
                if (model is INeedPlayer needPlayer)
                {
                    needPlayer.SetPlayer(playerModel);
                }
            });
        }

        public IEnumerator EnenmyAct()
        {
            foreach (var model in _enemyModels)
            {
                if (model is IPlayCard playCard)
                {
                    if(model.View!=null)
                        yield return playCard.Play();
                }
            }
            OnEnemyActionIsFinished?.Invoke();
        }

        public bool CanAct()
        {
            for (int i = 0; i < _enemyModels.Count; i++)
            {
                if (_enemyModels[i].View != null)
                {
                    return true;
                }
            }

            return false;
        }

        public event Action OnEnemyActionIsFinished;
    }
}