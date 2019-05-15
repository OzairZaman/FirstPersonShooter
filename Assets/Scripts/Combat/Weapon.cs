using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{

    public int damage;
    public float attackRange = 10f, attackRate = 1f;
    public bool canAttack = false;
    public float attackTimer = 0f;



    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= 1f / attackRate)
        {
            canAttack = true;
        }
    }

    //call the base.Attack() functoin to reset the ability to attack
    public virtual void Attack()
    {
        // reset timer
        attackTimer = 0f;
        // reset can attack
        canAttack = false;
    }
}
