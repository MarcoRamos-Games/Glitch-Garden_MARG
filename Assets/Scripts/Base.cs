using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        
            FindObjectOfType<HealthDisplay>().TakeLife();
            Destroy(otherCollider.gameObject);
        
    }
}
