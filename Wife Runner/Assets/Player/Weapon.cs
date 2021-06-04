using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 550f;
    [SerializeField] int damage = 30;
    [SerializeField] ParticleSystem shootFlash;
    [SerializeField] GameObject hitFlash;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    private void Shoot() {
        PlayShootAnimation();
        ProcessRayCast();
    }

    private void PlayShootAnimation() {
        shootFlash.Play();
    }

    private void ProcessRayCast() {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)){
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        } else {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit) {
       GameObject impact = Instantiate(hitFlash, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
    }
}
