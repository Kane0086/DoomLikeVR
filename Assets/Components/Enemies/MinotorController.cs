using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinotorController : MonoBehaviour
{

    public Transform player;
    private NavMeshAgent agent;
    private Transform pos;
    public Rigidbody Bullet;
    public Transform Spawner;
    private Animator animator;
    private float delay = 1;
    private float timer;
    private bool start_animation_run = false;
    private bool start_animation_shoot = false;
    private Rigidbody self_body;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pos = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        self_body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float distance = Vector3.Distance(player.transform.position, pos.transform.position);
        if (distance > 20 || SeePlayer() == false)
        {
            agent.SetDestination(player.position);
            animator.SetBool("Walk", true);
            animator.SetBool("Shoot", false);
        }
        else
        {
            agent.isStopped = true;
            agent.ResetPath();
            animator.SetBool("Walk", false);
            self_body.velocity.Set(0, 0, 0);
            animator.SetBool("Shoot", false);
            if (timer > delay)
            {
                animator.SetBool("Shoot", true);
                shoot();
                timer = 0;
            }
        }
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

        print(rayDirection);
        if (Physics.Raycast(pos.position, rayDirection, out hit))
        {
            if (hit.transform == player)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }
}
