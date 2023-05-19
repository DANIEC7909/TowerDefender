using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnar : EnemyBase
{
    // Start is called before the first frame update
    void Start()
    {
        Init(GameController.Instance.CurrentLevelSpline);
        Health = 100;
        CanAttackTowers = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBySpline(UnitSpeed);
    }
}
