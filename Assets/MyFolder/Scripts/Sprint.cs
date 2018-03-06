using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprint : MonoBehaviour {
    [SerializeField]
    private GameObject Center;
    private float xzero;
    private float sinpuku;
    [SerializeField]
    private float kakusinndousuu;
    private void Start()
    {
        transform.parent = Center.transform;

    }

    private float Pos(float t) {
        return xzero + sinpuku * Mathf.Sin(kakusinndousuu * t);
    }
}
