﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HugeFrappe : MonoBehaviour
{
    public Animator cameraAnimator;
    private Animator armAnimator;
    public Camera armCamera;

    public void Start()
    {
        armAnimator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            armAnimator.Play("arm_huge_frappe", 0, 0.0f);
            cameraAnimator.Play("camera_hit", 0, 0.0f);

            Hit();
        }
    }

    private void Hit()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(armCamera.transform.position, armCamera.transform.forward, out hit, Utils.HugeFrappeReach)) {
            MeshExploder meshExploder = hit.transform.gameObject.GetComponent<MeshExploder>();
            if (meshExploder) {
                meshExploder.Explode(hit.point, transform.forward);
            }
        }
        //TODO : WIP faut refactor ca
        if (Physics.Raycast(armCamera.transform.position, armCamera.transform.forward, out hit, Utils.HugeFrappeReach)) {
            SpawnExploder meshExploder = hit.transform.gameObject.GetComponent<SpawnExploder>();
            if (meshExploder) {
                meshExploder.Explode(hit.point, transform.forward * 10f, 50f);
            }
        }
    }
}
