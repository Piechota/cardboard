using UnityEngine;
using System.Collections;

public class CheckpointScore : MonoBehaviour {

    public GameObject getPointParticle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        GameController.instance.score += 1;
        (GameObject.Instantiate(getPointParticle, transform.position, GameController.instance.player.transform.rotation) as GameObject).transform.parent = GameController.instance.player.transform;
        Destroy(transform.parent.gameObject);
    }
}
