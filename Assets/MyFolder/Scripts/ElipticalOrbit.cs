using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ElipticalOrbit {


    private Vector3 O1{ get; set; }
    private Vector3 O2{get;set;}
    private float Ra { get; set; }
    private Vector3 Axisa { get; set; }
    private float Rb { get; set; }
    private Vector3 Axisb { get; set; }
    private Vector3 Center { get; set; }
    private Vector3 StartPos { get; set; }
    private float ConstS { get; set; }
    private float T { get; set; }

    public ElipticalOrbit(Vector3 o1,Vector3 o2,Vector3 startPos,float MaxSpeed) {
        Center = (o1 + o2) / 2.0f;
        O1 = o1 - Center;
        O2 = o2 - Center;
        StartPos = startPos - Center;
        float constR = (StartPos - O1).sqrMagnitude + (StartPos - O2).sqrMagnitude;
        Ra = constR / 2.0f;
        Axisa = O1.normalized;
        float ab = Vector3.Dot(Axisa,StartPos.normalized);
        float p = -ab / (1-ab);
        float r = (O1 - O2).sqrMagnitude / 2.0f;
        Rb = Mathf.Sqrt(Ra*Ra-r*r);
        Axisb = (p * Axisa + (1 - p) * StartPos.normalized).normalized;
        ConstS = (Ra - r)*(Ra - r)*MaxSpeed;
    }

    public Vector3 GetPos(Vector3 nowPos) {
        float l = (nowPos - O1).sqrMagnitude;
        float w = Omega(l);
        //Debug.Log(w);
        T += w * Time.deltaTime;
        Vector3 result = new Vector3
        {
            x = Ra * Axisa.x * Mathf.Cos(T) + Rb * Axisb.x * Mathf.Sin(T),
            y = Ra * Axisa.y * Mathf.Cos(T) + Rb * Axisb.y * Mathf.Sin(T),
            z = Ra * Axisa.z * Mathf.Cos(T) + Rb * Axisb.z * Mathf.Sin(T)
        };
        return result;
    }
    private float Omega(float nowPos) {
        return ConstS /( nowPos*nowPos);
    }
}
