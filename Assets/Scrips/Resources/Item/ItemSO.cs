using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]

public class ItemSO : ScriptableObject
{
    public Vector2 circleColliderOffset;
    public float circleColliderRadius;

}
