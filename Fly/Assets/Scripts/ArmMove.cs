using UnityEngine;
using System.Collections;

public class ArmMove : MonoBehaviour {

    public float maxRotate;

    private float rotateScale;

    void Awake()
    {
        rotateScale = maxRotate / 1f; //scale 1/x = maxRotate/y; x = Mouse X, y = current angle
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        float mouseDelta = -Input.GetAxis("Mouse X");
        mouseDelta = Mathf.Min(Mathf.Abs(mouseDelta), 1) * Mathf.Sign(mouseDelta);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3(0, -mouseDelta * rotateScale * 2, 0)), 0.05f);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3(0, 0, mouseDelta * rotateScale * 2)), 0.1f);

        mouseDelta = -Input.GetAxis("Mouse Y");
        mouseDelta = Mathf.Min(Mathf.Abs(mouseDelta), 1) * Mathf.Sign(mouseDelta);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3(mouseDelta * rotateScale, 0, 0)), 0.05f);
    }
}
