using System;
using System.Collections;
using System.Collections.Generic;
using Code.Configs;
using Code.Models;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    [SerializeField]
    private GameObject environment;
    [SerializeField]
    private GameObject playerSpawnPoint;
    [SerializeField]
    private List<EnemySpawnPointData> enemySpawnPoints;
    
    [Serializable]
    public class EnemySpawnPointData
    {
        public GameObject spawnPoint;
        public EnemyData enemyModelData;
    }
    
    public LevelModel Create()
    {
        List<KeyValuePair<GameObject, EnemyModel>> enemySpawnPointsList = new List<KeyValuePair<GameObject, EnemyModel>>();

        foreach (var spawnPointData in enemySpawnPoints)
        {
            var enemyModel = spawnPointData.enemyModelData.Create();
            enemySpawnPointsList.Add(new KeyValuePair<GameObject, EnemyModel>(spawnPointData.spawnPoint, enemyModel));
        }

        return new LevelModel(environment, playerSpawnPoint, enemySpawnPointsList);
    }
}