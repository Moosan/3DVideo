using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ziten : MonoBehaviour {
    public float RotateSpeed;
    private bool Rotate=true;
    [SerializeField]
    private Yoici yoi;
    private void Update()
    {
        if (!Rotate) return;
        transform.localEulerAngles = transform.localEulerAngles +new Vector3(0,RotateSpeed*Time.deltaTime,0);
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Rotate = !Rotate;
            yoi.SetRotateBool();
        }
    }
}
