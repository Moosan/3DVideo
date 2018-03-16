using UnityEngine;
using System.Collections;

public class ActiveStateToggler : MonoBehaviour {

    
	public void ToggleActive () {
		gameObject.SetActive (!gameObject.activeSelf);
        ResetRotate();
        transform.GetComponent<Animator>().SetBool("Next", gameObject.activeSelf);
	}
    private void ResetRotate() {
        transform.rotation = Quaternion.Euler(0,-90,0);
    }
}
