using UnityEngine;
using System.Collections;

public class StartCutScene : MonoBehaviour {
    public float flyTime;
    public float destinyTime;
    public float sinSpeed;

    public Transform destiny;
    public Transform flyStart;

    public Transform arm;
    public Transform startArm;
    public Transform endArm;

    protected Vector3 startPosition;
    protected Vector3 startForward;
    protected float startTime;

    protected Vector3 XZposition;
	// Use this for initialization
	void Start () {
        startPosition = XZposition = transform.position;
        startTime = Time.time;
        startForward = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {
        if ((flyStart.position - XZposition).normalized == (flyStart.position - startPosition).normalized)
        { 
            XZposition = Vector3.Lerp(startPosition, flyStart.position, (Time.time - startTime) / flyTime);
            transform.position = XZposition + Vector3.up * Mathf.Sin(((Time.time - startTime) * sinSpeed)) * 0.5f;

            if (Vector3.Distance(XZposition, flyStart.position) < 0.1f)
                transform.position = flyStart.position;
        }
        else
            XZposition = transform.position = Vector3.Lerp(flyStart.position, destiny.position, (Time.time - (startTime + flyTime)) / (destinyTime - flyTime));

        if ((flyStart.position - XZposition).normalized != (flyStart.position - startPosition).normalized)
        {
            if ((Vector3.Distance(flyStart.position, transform.position) / Vector3.Distance(flyStart.position, destiny.position)) <= 0.99)
            {
                arm.position = Vector3.Lerp(startArm.position, endArm.position, Vector3.Distance(flyStart.position, transform.position) / Vector3.Distance(flyStart.position, destiny.position));

                transform.rotation = Quaternion.LookRotation(Vector3.Lerp(startForward, (destiny.position - transform.position).normalized, Vector3.Distance(flyStart.position, transform.position) / Vector3.Distance(flyStart.position, destiny.position)));
            }
        }

        if (Vector3.Distance(transform.position, destiny.position) <= 0.01f)
        {
            (GetComponent(typeof(Flying)) as Flying).enabled = true;
            Destroy(this); 
        }
	}
}
