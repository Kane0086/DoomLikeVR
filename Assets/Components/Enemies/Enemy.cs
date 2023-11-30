using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected int healthPoint = 5;

    protected void IsDead()
    {
        if (healthPoint <= 0)
            Destroy(this);
    }
}
