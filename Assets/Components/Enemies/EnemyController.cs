using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int healthPoints = 50;
    public Transform player;
    private NavMeshAgent agent;
    private Transform pos;
    public Rigidbody Bullet;
    public Transform Spawner;
    private Animator animator;
    private float delay = 1;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pos = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("PlayerVR").transform.Find("XR Origin (XR Rig)");
    }

    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
            healthPoints -= 5;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float distance = Vector3.Distance(player.transform.position, pos.transform.position);
        if (distance > 15 || SeePlayer() == false)
        {
            animator.SetBool("IsMoving", true);
            animator.SetBool("Attack", false);
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            animator.SetBool("IsMoving", false);
            agent.isStopped = true;
            animator.SetBool("Attack", false);
            if (timer > delay)
            {
                animator.SetBool("Attack", true);
                shoot();
                timer = 0;
            }
        }
        if (healthPoints <= 0)
            Destroy(gameObject);
    }

    void shoot()
    {
        Rigidbody clone;
        clone = Instantiate(Bullet, Spawner.transform.position, Quaternion.identity);
        clone.transform.rotation = this.transform.rotation;
        clone.velocity = Spawner.TransformDirection(Vector3.back * 50);
        Destroy(clone.gameObject, 5);

    }

    bool SeePlayer()
    {
        var rayDirection = player.position - pos.position;
        RaycastHit hit;

        if (Physics.Raycast(pos.position, rayDirection, out hit))
            return hit.transform == player;
        return false;
    }
}
