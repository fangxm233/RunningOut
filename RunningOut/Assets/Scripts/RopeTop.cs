using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeTop : MonoBehaviour {

	// Use this for initialization
	//void Start () {}
	
	// Update is called once per frame
	void Update ()
    {
        if (!GetComponent<Tween>().is_moving)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
	}
}
