﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleExploder : IExploder
{
    public List<GameObject> Explode(Vector3 impact, Vector3 direction, GameObject original)
    {
        Vector3 size = original.transform.localScale;
        Vector3 offset = new Vector3(
            impact.x,
            impact.y,
            impact.z
        );


        //Vector3 p1 = offset + new Vector3(2, 0, 1);
        //Vector3 p2 = offset + new Vector3(-2, 0, 1);
        //Vector3 p3 = offset + new Vector3(0, 0, -2);

        //Plane plane = new Plane(
        //    original.transform.InverseTransformPoint(p1),
        //    original.transform.InverseTransformPoint(p2),
        //    original.transform.InverseTransformPoint(p3)
        //);

        Plane plane = new Plane(
            original.transform.InverseTransformPoint(offset + new Vector3(0, 0, 1)),
            original.transform.InverseTransformPoint(offset + new Vector3(1, 0, 0)),
            original.transform.InverseTransformPoint(offset + new Vector3(-1, 0, 0))
        );

        // We want the plane's normal to face up so that the upper part is upper on the y axis than the lower part
        //if (original.transform.up.y < 0) {
            //plane = plane.flipped;
        //}

        List<GameObject> parts = MeshSlicerUtility.Slice(original, plane);

        if (parts.Count > 1) {
            foreach(GameObject part in parts) {
                MeshCollider meshCollider = part.AddComponent<MeshCollider>();
                meshCollider.convex = true;
                meshCollider.sharedMesh = part.GetComponent<MeshFilter>().sharedMesh;
                
                Rigidbody rigidbody = part.AddComponent<Rigidbody>();
                rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
                rigidbody.AddForce(direction * Utils.HugeFrappePower, ForceMode.Impulse);

                part.AddComponent<MeshExploder>().exploderType = ExplodeType.Simple;
            }
        }

        return parts;
    }
}
