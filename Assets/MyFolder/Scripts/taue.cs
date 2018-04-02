using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taue : MonoBehaviour
{
    [SerializeField]
    private GameObject ine;
    [SerializeField]
    private float kankaku;
    [SerializeField]
    private int kosu;
    [SerializeField]
    private Vector3 Rotate;
    // Use this for initialization
    void Start()
    {
        ine.SetActive(false);
        for (int i = 0; i < kosu; i++)
        {
            for (int j = 0; j < kosu; j++)
            {
                GameObject obj = Instantiate(ine);
                obj.transform.parent = transform;
                obj.transform.localPosition = new Vector3(kankaku * i, kankaku * j, 0);
                obj.transform.localRotation = Quaternion.Euler(Rotate);
                obj.SetActive(true);
            }
        }
    }
}
