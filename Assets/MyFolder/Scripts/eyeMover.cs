using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
public class eyeMover : MonoBehaviour {

    [SerializeField]
    private Slider iti;
    [SerializeField]
    private InputField itii;
    void Start () {
        itii.OnEndEditAsObservable().Subscribe(value => ItiChange(float.Parse(value)));
        iti.OnValueChangedAsObservable().Subscribe(value => ItiChange(value));
    }
    private void ItiChange(float pos) {
        var before = transform.position;
        before.z = -pos;
        transform.position = before;
        itii.text = pos.ToString();
    }
}
