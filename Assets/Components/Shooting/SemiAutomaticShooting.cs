using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SemiAutomaticShooting : GunBehavior
{
    public GameObject bullet;
    public float speed;

    public void Shooting()
    {
        if (_isReloading == true)
            return;
        if (loaded <= 0)
            Reload();
        var obj = Instantiate(bullet, transform.position, transform.rotation);
        loaded -= 1;
        var rb = obj.GetComponent<Rigidbody>();
        var front = obj.transform.Find("Front");
        rb.velocity = (front.position - rb.gameObject.transform.position) * speed;
        print(rb.velocity);
        Destroy(obj, 5);
    }
}