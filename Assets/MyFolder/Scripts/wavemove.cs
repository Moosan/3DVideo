using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wavemove : MonoBehaviour {

    [SerializeField]
    private float MoveSpeed;
    [SerializeField]
    private float MoveRange;
	// Update is called once per frame
	void Update () {
        transform.localPosition = new Vector3(0,2,MoveRange*Mathf.Sin(Time.time*MoveSpeed));
	}
}
