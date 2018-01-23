using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
public class MaterialChanger : MonoBehaviour {
    [SerializeField]
    private Material rc, gm, by;

    private MeshRenderer mesh { get; set; }

	void Start () {
        mesh = GetComponent<MeshRenderer>();
	}

    public void ColorChange(int number) {
        if (number == 0)
        {
            mesh.material = rc;
        }
        else if (number == 1)
        {
            mesh.material = gm;
        }
        else
        {
            mesh.material = by;
        }
    }
}
