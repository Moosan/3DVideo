using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowCamera : MonoBehaviour {
    [SerializeField]
    private Transform eye;
	void Update () {
        transform.localPosition = new Vector3(eye.transform.position.x,transform.position.y,eye.transform.position.z);
        transform.localEulerAngles = new Vector3(0,eye.transform.localEulerAngles.y,0);
	}
}
