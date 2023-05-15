using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract class Singleton : MonoBehaviour
{
  
   protected void Init()
    {
        DontDestroyOnLoad(this);
        GameObject go = GameObject.FindGameObjectWithTag(transform.tag);
       
        if(go!=null && go!=gameObject)
        {
            Destroy(go);
        }
    }

}
