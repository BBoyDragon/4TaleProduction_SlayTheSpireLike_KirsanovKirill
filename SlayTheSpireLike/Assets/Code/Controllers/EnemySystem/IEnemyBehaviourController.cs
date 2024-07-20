using System;
using System.Collections;
using Unity.VisualScripting;

namespace Code.Controllers.EnemySystem
{
    public interface IEnemyBehaviourController
    {
        public IEnumerator EnenmyAct();
        public bool CanAct();
        public event Action OnEnemyActionIsFinished;
    }
}