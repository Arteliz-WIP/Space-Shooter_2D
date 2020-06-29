using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    public float HitPoints;
    public float MaxHitPoints = 3;

    private void Start()
    {
        HitPoints = MaxHitPoints;
    }

}
