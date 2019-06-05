using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SteeringBehavior : MonoBehaviour
{
    public float weight = 7.5f;

    public abstract Vector3 GetForce(AI owner);
    
}
