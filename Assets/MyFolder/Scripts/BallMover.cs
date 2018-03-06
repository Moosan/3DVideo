using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour {
    [SerializeField]
    private Vector3 o1, o2;

    private ElipticalOrbit orbit;

    [SerializeField]
    private float MaxSpeed;

	void Start () {
        orbit = new ElipticalOrbit(o1,o2,transform.position,MaxSpeed);
	}
	
	void Update () {
        transform.position= orbit.GetPos(transform.position);
	}
}
