using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour

    
{
    public bool hunt = false;
    public GameObject allyObject;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ally"))
        {
            allyObject = other.gameObject;
            hunt = true;
            Debug.Log("¿’Œ“¿");
        }
    }
}
