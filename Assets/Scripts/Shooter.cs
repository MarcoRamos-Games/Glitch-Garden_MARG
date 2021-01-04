using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    AtackerSpawner myLaneSpawner;
    Animator animator;
    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "projectiles";
    private void Start()
    {
        animator = GetComponent<Animator>();
        SetLaneSpawner();
        CreateProjectileParent();
        
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if (IsAtackerInLane())
        {
            animator.SetBool("isAtacking", true);
        }
        else
        {
            animator.SetBool("isAtacking", false);
        }
    }


    private void SetLaneSpawner()
    {
        AtackerSpawner[] spawners = FindObjectsOfType<AtackerSpawner>();

        foreach(AtackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs (spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAtackerInLane()
    {
       if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
       else
        {
            return true;
        }
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity)as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }

   
}
