using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
public class EnemySO : ScriptableObject
{
    public Enemy enemyName;
    public int hp;
    public Vector2 colliderOffset;
    public Vector2 colliderSize;
}

public enum Enemy
{
    No = 0,
    Enemy_1 = 1,
    Enemy_2 = 2,
    Enemy_3 = 3,
    Enemy_4 = 4,    
}