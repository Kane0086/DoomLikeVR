using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NormalShooting : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public AudioClip shootingSound;
    private AudioSource source;

    void Awake() {
        source = GetComponent<AudioSource>();
        source.volume = 0.5F;
    }

    public void Shooting()
    {
        source.PlayOneShot(shootingSound);
        var obj = Instantiate(bullet, transform.position, transform.rotation);
        var rb = obj.GetComponent<Rigidbody>();
        var front = obj.transform.Find("Front");
        rb.velocity = (front.position - rb.gameObject.transform.position) * speed;
        print(rb.velocity);
        Destroy(obj, 5);
    }
}
