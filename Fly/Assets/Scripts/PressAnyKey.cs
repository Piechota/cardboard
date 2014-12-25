using UnityEngine;
using System.Collections;

public class PressAnyKey : MonoBehaviour {

    public GameObject pressKey;

    protected Vector3 startPosition;

	// Use this for initialization
	void Start () {
        startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = startPosition + Vector3.up * Mathf.Sin(Time.time) * 0.05f;

	    if(Input.anyKey)
        {
            Destroy(pressKey);
            (GetComponent(typeof(StartCutScene)) as StartCutScene).enabled = true;
            transform.position = startPosition;
            Destroy(this);
        }
	}
}
