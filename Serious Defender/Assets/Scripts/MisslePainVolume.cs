using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisslePainVolume : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 0.5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            other.transform.GetComponent<EnemyBase>().DealDamage(999);

        }
    }
}
