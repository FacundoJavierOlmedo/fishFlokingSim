using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFood : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector3(Random.Range(-40,40), transform.position.y, Random.Range(426, 511));
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        transform.position = new Vector3(Random.Range(-40, 40), transform.position.y, Random.Range(426, 511));
    }
}
