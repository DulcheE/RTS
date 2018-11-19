using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Debug.Log("Click");
        Select.pos = new Vector2(transform.position.x, transform.position.y);
    }
}
