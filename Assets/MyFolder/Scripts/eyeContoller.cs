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
        kyo.OnEndEditAsObservable().Subscribe(value => sisaChange(float.Parse(value)));
        kak.OnEndEditAsObservable().Subscribe(value => kakuChange(float.Parse(value)));
        kyori.OnValueChangedAsObservable().Subscribe(value => sisaChange(value));
        kaku.OnValueChangedAsObservable().Subscribe(value => kakuChange(value));
    }
    private void sisaChange(float sisa) {
        RightCamera.transform.localPosition = new Vector3(sisa, 0, 0);
        LeftCamera.transform.localPosition = new Vector3(-1 * sisa, 0, 0);
        kyo.text = sisa.ToString();
    }
    private void kakuChange(float kaku) {
        if (kyori.value < 0) {
            kaku *= -1;
        }
        RightCamera.transform.localRotation = Quaternion.Euler(new Vector3(0, -1 * kaku, 0));
        LeftCamera.transform.localRotation = Quaternion.Euler(new Vector3(0, kaku, 0));
        kak.text = kaku.ToString();
    }
}
