using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObjects/Bullet")]
public class BulletSO : ScriptableObject
{
    public int damage;
    public Vector2 circleColliderOffset;
    public float circleColliderRadius;
}
