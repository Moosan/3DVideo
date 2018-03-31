using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ziten : MonoBehaviour {
    public float RotateSpeed;
    private void Update()
    {
        transform.localEulerAngles = transform.localEulerAngles +new Vector3(0,RotateSpeed*Time.deltaTime,0);
    }
}
