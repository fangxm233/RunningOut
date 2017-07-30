using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager game_manager;
    public GameObject gaming_ui;
    public bool started;

    void Awake()
    {
        game_manager = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void GameStart()
    {
        //gaming_ui.SetActive(true);
        started = true;
    }
}
