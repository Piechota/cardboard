using UnityEngine;
using System.Collections;

public class BillboardDestroy : MonoBehaviour {
    public float timeToDestroy;

    protected bool isDestroyed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(isDestroyed)
        {
            if (timeToDestroy < 0)
                Destroy(gameObject);

            timeToDestroy -= Time.deltaTime;
        }
	}

    void OnTriggerEnter(Collider other)
    {
        Component[] cmps = GetComponentsInChildren(typeof(Rigidbody));
        foreach (Rigidbody r in cmps)
        {
            r.isKinematic = false;
            r.WakeUp();

            Vector3 force = GameController.instance.player.transform.forward * 13000f;
            r.AddExplosionForce(10000f, GameController.instance.player.transform.position, 100f);
            r.AddForce(force);
        }
        isDestroyed = true;
    }
}
