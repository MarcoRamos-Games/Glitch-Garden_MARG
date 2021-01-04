using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<HorseMan>())
        {
            GetComponent<Atacker>().Jump();
        }
        else if (otherObject.GetComponent<Defender>())
        {
            GetComponent<Atacker>().Atack(otherObject);
        }
        
    }
}
