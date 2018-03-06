using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
public class eyeContoller : MonoBehaviour {

    [SerializeField]
    private Slider kyori, kaku;
    [SerializeField]
    private InputField kyo, kak;
    [SerializeField]
    private GameObject RightCamera;
    [SerializeField]
    private GameObject LeftCamera;

	void Start () {
        kyo.OnValueChangedAsObservable().Subscribe(value => sisaChange(Parse(value)));
        kak.OnValueChangedAsObservable().Subscribe(value => kakuChange(Parse(value)));
        kyori.OnValueChangedAsObservable().Subscribe(value => sisaChange(value));
        kaku.OnValueChangedAsObservable().Subscribe(value => kakuChange(value));
    }
    private void sisaChange(float sisa) {
        RightCamera.transform.localPosition = new Vector3(sisa, 0, 0);
        LeftCamera.transform.localPosition = new Vector3(-1 * sisa, 0, 0);
        kyo.text = sisa.ToString();
    }
    private void kakuChange(float kaku) {
        RightCamera.transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, -1 * kaku, 0));
        LeftCamera.transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x, kaku, 0));
        kak.text = kaku.ToString();
    }
    private float Floor(float value) {
        return (Mathf.Round(1000 * value) / 1000f);
    }
    private float Parse(string value) {
        if (string.IsNullOrEmpty(value))
        {
            return 0f;
        }
        else {
            return float.Parse(value);
        }
    }
}
