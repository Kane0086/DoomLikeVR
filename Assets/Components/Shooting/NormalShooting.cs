using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalShooting : MonoBehaviour
{
    public GameObject bullet;
    public float speed;

    public void Shooting()
    {
        var obj = Instantiate(bullet, transform.position, transform.rotation);
        var rb = obj.GetComponent<Rigidbody>();
        var front = obj.transform.Find("Front");
        rb.velocity = (front.position - rb.gameObject.transform.position) * speed;
        print(rb.velocity);
        Destroy(obj, 5);
    }
}
