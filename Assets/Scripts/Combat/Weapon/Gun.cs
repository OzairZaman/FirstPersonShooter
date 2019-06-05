using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : Weapon
{

    public int maxReserve = 500, maxClip = 30;
    public float spread = 2f, recoil = 1f;
    public Transform shotOrigin;
    public GameObject projetilePrefab;

    private int currentReserve = 0, currentClip = 0;

    // Start is called before the first frame update
    void Start()
    {
        Reload();
    }

    // Update is called once per frame
    void Reload()
    {
        // If there is ammo in reserve
        if (currentReserve > 0)
        {
            // If reserve is greater than max clip
            if (currentReserve >= maxClip)
            {
                // Remove difference from current reserve
                int difference = maxClip - currentClip;
                currentReserve -= difference;
                // Replenish entire clip with max clip
                currentClip = maxClip;
            }
            // If clip is lower than max clip size
            if(currentReserve < maxClip)
            {
                // Set entire clip to reserve
                currentClip += currentReserve;
                currentReserve -= currentReserve;
            }
        }
    }

    public override void Attack()
    {
        //attack logic
        // reduce the clip
        currentClip--;
        //get origin + direction for bullet
        Camera attachCamera = Camera.main;
        Transform camTransform = attachCamera.transform;
        Vector3 lineOrigin = shotOrigin.position;
        Vector3 direction = camTransform.forward;
        //spawn bullet
        GameObject clone = Instantiate(projetilePrefab, camTransform.position, camTransform.rotation);
        Bullet bullet = clone.GetComponent<Bullet>();
        bullet.Fire(lineOrigin, direction);
        
        base.Attack();
    }
}
