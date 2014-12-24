using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    public static GameController instance { get; private set; }


    private int _score = 0;
    public int score
    {
        get { return _score; }
    set
        {
            _score = value;
            scoreText.text = _score.ToString();
        }
    }

    public Text scoreText;
    public GameObject player;

    void Awake()
    {
        instance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
