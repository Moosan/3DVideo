using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvRotate : MonoBehaviour {
    [SerializeField] private float RotateSpeed;
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0,0,RotateSpeed*Time.time);
    }
}
