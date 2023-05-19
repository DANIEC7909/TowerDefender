using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemyPack
{
    public EnemyBase Type;
    public int Amount;
    public float SpawnTime;
}
[System.Serializable]
public struct Wave
{
    public List<EnemyPack> EnemyTypesInWave;
    
}



[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData", order = 0)]
public class LevelObject : ScriptableObject
{
    public List<Wave> WaveScenario;
}
