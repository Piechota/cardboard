using UnityEngine;
using System.Collections;

public class PressAnyKey : MonoBehaviour {

    public GameObject pressKey;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.anyKey)
        {
            Destroy(pressKey);
            (GetComponent(typeof(StartCutScene)) as StartCutScene).enabled = true;
            Destroy(this);
        }
	}
}
