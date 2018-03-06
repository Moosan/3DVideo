using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoici : MonoBehaviour {
    [SerializeField]private GameObject obj;
    [SerializeField]private float R;
    [SerializeField]private float H;
    private float deltangle;
    [SerializeField]private int objCount;
    private RotateObj[] objArray;
    [SerializeField] private float RotateSpeed;
    public bool rotate;
    private void Start()
    {
        RotateObj.SetValue(R);
        deltangle = 360 / (float)objCount;
        obj.transform.parent = transform;
        obj.SetActive(true);
        objArray = new RotateObj[objCount];
        objArray[0] = new RotateObj(obj, 0, H);
        objArray[0].UpdatePos();
        
        for (int i = 1; i < objCount; i++) {
            var ob = Instantiate(obj);
            ob.transform.parent = transform;
            ob.SetActive(true);
            objArray[i] = new RotateObj(ob, i * deltangle, H);
            objArray[i].UpdatePos();
        }
    }
    private void FixedUpdate()
    {
        if (!rotate) return;
        var ang = RotateSpeed * Time.deltaTime;
        foreach (var ob in objArray) {
            ob.AddAngle(ang);
            ob.UpdatePos();
        }
    }
}
public class RotateObj {
    private GameObject obj;
    private float angle;
    private static float r;
    private float h;
    public static void SetValue(float r) {
        RotateObj.r = r;
    }

    public RotateObj(GameObject obj,float angle,float h) {
        this.obj = obj;
        this.angle = angle;
        this.h = h;
    }
    public void UpdatePos() {
        var x = r*Mathf.Cos(Mathf.PI*angle/180);
        var z= r*Mathf.Sin(Mathf.PI * angle / 180);
        obj.transform.localPosition = new Vector3(x,h,z);
    }
    public void AddAngle(float addAngle) {
        angle += addAngle;
        if (angle > 360) {
            angle -= 360;
        }
    }
}