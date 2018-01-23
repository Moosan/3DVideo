using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterFly : MonoBehaviour {
    public float RotateSpeed;
    private bool haneDown;
    private float rotaition;
    public int MaxRotate;
    public int MinRotate;
    void Awake() {
        haneDown = true;
        rotaition = 60;
        right = haneRight.transform;
        left = haneLeft.transform;
    }


    void Update() {
        var delta = RotateSpeed * Time.deltaTime;
        rotaition = rotaition + (haneDown?delta:-delta);
        right.localEulerAngles = new Vector3(rotaition,-20,-90);
        left.localEulerAngles = new Vector3(-rotaition, -20, -90);
    }
    
    [SerializeField]
    private GameObject haneRight;
    [SerializeField]
    private GameObject haneLeft;

    private Transform right;
    private Transform left;
}
