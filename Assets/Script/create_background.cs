using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_background : MonoBehaviour {
    public int x;
    public int y;
    public GameObject prefab_grid_empty;

	// Use this for initialization
	void Start () {

		Vector3 v_grid = new Vector3();
		float i, j;


		for(i = -x/2; i <= x/2; i++){
			for(j = -y/2; j <= y/2; j++){
				v_grid.Set(i*1.25f, j*1.25f, 0);
		    
		    	GameObject.Instantiate(prefab_grid_empty, v_grid, transform.rotation);
	    	}
    	}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
