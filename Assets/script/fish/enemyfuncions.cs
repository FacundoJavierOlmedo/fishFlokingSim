using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyfuncions : MonoBehaviour
{
    public static int numberofenemys;
    // Start is called before the first frame update
    private void Awake()
    {
        if (numberofenemys != 0)
            numberofenemys = 0;
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("player"))
        {
           // EventManager.instance.Trigger("OnPlayerHitEnemy");


        }

        if (other.gameObject.layer == LayerMask.NameToLayer("bullet"))
        {
           // EventManager.instance.Trigger("OnEnemyDeath");

         
            gameObject.SetActive(false);

            
            


        }
    }
}
