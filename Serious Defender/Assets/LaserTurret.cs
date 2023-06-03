using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTurret : TurretBase
{

    void Start()
    {
        Init();
    }

    void Update()
    {
        Tick();
    }
}
