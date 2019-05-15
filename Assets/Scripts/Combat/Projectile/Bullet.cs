using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    public float speed = 10f;
    private Rigidbody rigid;
    public Transform line;
    public GameObject effectPrefab;
    
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity.magnitude > 0f)
        {
            line.rotation = Quaternion.LookRotation(rigid.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (effectPrefab)
        {
            //get contact
            ContactPoint contact = collision.contacts[0];
            //span effect and rotate to contact normal
            Instantiate(effectPrefab, contact.point, Quaternion.LookRotation(contact.normal)); //the end part there is converting the vector to a quaternion orientation
        }

        //destroy bullet
        Destroy(gameObject);
    }

    public override void Fire(Vector3 lineOrogin, Vector3 direction)
    {
        //use forcemode Impulse for immidiate force in situation like bullets / jump etc. Def not player movement. 
        rigid.AddForce(direction * speed, ForceMode.Impulse);
        line.position = lineOrogin;
        
    }

    
}
