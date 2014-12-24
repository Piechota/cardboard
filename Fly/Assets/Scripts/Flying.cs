using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Flying : MonoBehaviour {

    public float speed;
    public float rotateSpeed;

	// Use this for initialization
	void Start () {
        GameController.instance.player = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        rigidbody.MovePosition(rigidbody.position + transform.forward * speed * Time.deltaTime);
        rigidbody.velocity = Vector3.zero;
        Rotate(Time.deltaTime);
	}

    void Rotate(float deltaTime)
    {
        transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * deltaTime * rotateSpeed, 0f, 0f), Space.Self);
        transform.Rotate(new Vector3(0f, Input.GetAxis("Mouse X") * deltaTime * rotateSpeed, 0f), Space.World);
    }
}
