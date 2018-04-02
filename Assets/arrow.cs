using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {
	void Update () {
        transform.localEulerAngles = new Vector3(transform.parent.transform.parent.transform.localEulerAngles.x,180,0);
	}
}
