using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public int loaded = 7;
    public int inLoader = 35;
    public int toReload = 7;
    public float reloadDelay = 10;

    private float _reloadTimer;
    protected bool _isReloading = false;

    protected virtual void Update()
    {
        _reloadTimer += Time.deltaTime;
        if (_isReloading == true && _reloadTimer >= reloadDelay) {
            _isReloading = false;
            print("Here");
        }
    }

    public void Reload()
    {
        _isReloading = true;
        loaded += toReload;
        inLoader -= toReload;
        _reloadTimer = 0;
    }
}
