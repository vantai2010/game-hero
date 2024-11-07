using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemPickupable : CustomBehavior
{
    public abstract void HandleCollison(Collider2D other);
}
