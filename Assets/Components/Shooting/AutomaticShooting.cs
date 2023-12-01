using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AutomaticShooting : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public float delay = 0.5F;

    private bool isActivate;
    private float timer;

    public void Activate()
    {
        isActivate = true;
    }

    public void Desactivate()
    {
        isActivate = false;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (isActivate && timer > delay) {
            Shooting();
            timer = 0;
        }
    }

    private void Shooting()
    {
        var obj = Instantiate(bullet, transform.position, transform.rotation);
        var rb = obj.GetComponent<Rigidbody>();
        var front = obj.transform.Find("Front");
        rb.velocity = (front.position - rb.gameObject.transform.position) * speed;
        print(rb.velocity);
        Destroy(obj, 5);
    }
}