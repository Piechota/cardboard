using UnityEngine;
using System.Collections;

public class CheckpointActivate : MonoBehaviour {
    public GameObject particle;
    public GameObject trigger;

    public bool isTrigger = false;
    public bool isActivate = false;
    public CheckpointActivate next;
	// Use this for initialization
	void Start () {
        if (!isActivate)
            particle.SetActive(false);

        if (!isTrigger)
            trigger.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Activate()
    {
        particle.SetActive(true);
        isActivate = true;
    }

    public void SetTrigger()
    {
        isTrigger = true;
        trigger.SetActive(true);
    }

    void OnDestroy()
    {
        if (next)
        {
            next.SetTrigger();
            if (next.isActivate && next.next)
            {
                next.next.Activate();
            }
        }
    }
}
