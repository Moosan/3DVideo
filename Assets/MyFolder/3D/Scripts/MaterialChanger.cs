using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
public class MaterialChanger : MonoBehaviour {
    [SerializeField]
    private Material rc, gm, by;
    [SerializeField]
    private Material normal;
    private int nowNumber;
    private MeshRenderer mesh { get; set; }

	void Start () {
        nowNumber = 1;
        mesh = GetComponent<MeshRenderer>();
	}

    public void ColorChange(int number) {
        if (nowNumber == number) {
            mesh.material = normal;
            nowNumber = 0;
            return;
        }
        if (number == 1)
        {
            mesh.material = rc;
        }
        else if (number == 2)
        {
            mesh.material = gm;
        }
        else if(number ==3 )
        {
            mesh.material = by;
        }
        nowNumber = number;
    }
}
