using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
    [SerializeField]
    private float Size;
    [SerializeField]
    private float KouT;
    [SerializeField]
    private float ZiT;
    [SerializeField]
    private float Slope;
    [SerializeField]
    private Transform Center;
    [SerializeField]
    private float R;
    private float w;
    [SerializeField]
    private Vector3 RotateAxis;
    [SerializeField]
    private Vector3 RGB;
    private Vector3 xaxis,yaxis;
    private float ziw;
	void Start () {
        transform.localScale = new Vector3(1,1,1)*Size;
        w = 2 * Mathf.PI / KouT;
        xaxis = transform.localPosition.normalized;
        yaxis = Vector3.Cross(xaxis,RotateAxis).normalized;
        ziw = 360f / ZiT;
        RGB /= 100f;
        //GetComponent<MeshRenderer>().material.color = new Color(RGB.x,RGB.y,RGB.z);
	}
	
	void Update () {
        var t = Time.time;
        var cos = Mathf.Cos(w * t);
        var sin = Mathf.Sin(w * t);
        transform.position = new Vector3(
            cos * xaxis.x + sin * yaxis.x,
            cos * xaxis.y + sin * yaxis.y,
            cos * xaxis.z + sin * yaxis.z
            ) *R +Center.position;
        transform.localRotation = Quaternion.Euler(Slope,ziw*Time.time,0);
	}
}
