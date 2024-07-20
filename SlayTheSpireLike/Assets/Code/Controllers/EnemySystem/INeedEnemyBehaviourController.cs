using Code.Controllers.EnemySystem;

namespace Code.Configs
{
    public interface INeedEnemyBehaviourController
    {
        public void SetEnemyBehaviourController(IEnemyBehaviourController enemyBehaviourController);
    }
}