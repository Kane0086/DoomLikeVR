using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(AudioSource))]
public class AutomaticShooting : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public float delay = 0.5F;
    public AudioClip shootingSound;

    private AudioSource source;
    private bool isActivate;
    private float timer;

    void Awake() {
        source = GetComponent<AudioSource>();
        source.volume = 0.5F;
    }
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
        source.PlayOneShot(shootingSound);
        var obj = Instantiate(bullet, transform.position, transform.rotation);
        var rb = obj.GetComponent<Rigidbody>();
        var front = obj.transform.Find("Front");
        rb.velocity = (front.position - rb.gameObject.transform.position) * speed;
        print(rb.velocity);
        Destroy(obj, 5);
    }
}