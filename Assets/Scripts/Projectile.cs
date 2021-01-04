using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float currentSpeed = 1f;
    [SerializeField] float rotation = 1f;
    [SerializeField] float damage = 100;



    void Update()
    {

        transform.Translate(Vector2.right * currentSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.back, rotation * Time.deltaTime, Space.World);
       
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var atacker = otherCollider.GetComponent<Atacker>();

        if (atacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
