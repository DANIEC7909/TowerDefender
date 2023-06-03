using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTurret : TurretBase
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
