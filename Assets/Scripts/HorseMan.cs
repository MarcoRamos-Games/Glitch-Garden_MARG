using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMan : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Atacker atacker = otherCollider.GetComponent<Atacker>();

        if (atacker)
        {
            GetComponent<Animator>().SetBool("isAtacked", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("isAtacked", false);
        }

    }
}
