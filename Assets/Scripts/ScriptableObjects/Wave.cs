using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Wave", menuName = "ScriptableObjects/Waves", order = 1)]
public class Wave : ScriptableObject
{
    [field: SerializeField]
    public GameObject[] EnemyTypes { get; private set; }
 
    [field: SerializeField]
    public float TimeBeforeThisWave { get; private set; }
 
    [field: SerializeField]
    public float[] NumberTypesToSpawn { get; private set; }
}
