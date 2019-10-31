﻿using System;
using UnityEngine;


struct Triple<T>
{
    public T a;
    public T b;
    public T c;
}


class Triangle
{
    private readonly Triple<Vector3> _points;
    private Triple<Vector3> _normals;
    private Triple<Vector2> _uv;

    public Triangle(Vector3 pA, Vector3 pB, Vector3 pC)
    {
        this._points = new Triple<Vector3> {
            a = pA,
            b = pB,
            c = pC
        };

        this._normals = new Triple<Vector3>();
        this._uv = new Triple<Vector2>();
    }

    public void SetNormals(Vector3 nA, Vector3 nB, Vector3 nC)
    {
        this._normals.a = nA;
        this._normals.b = nB;
        this._normals.c = nC;
    }

    public void SetUV(Vector2 uvA, Vector2 uvB, Vector2 uvC)
    {
        this._uv.a = uvA;
        this._uv.b = uvB;
        this._uv.c = uvC;
    }

    public Triple<Vector3> points {
        get { return this._points; }
    }

    public Triple<Vector3> normals {
        get { return this._normals; }
    }

    public Triple<Vector2> uv {
        get { return this._uv; }
    }
}