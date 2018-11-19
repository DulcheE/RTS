using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class create_out_of_the_map : MonoBehaviour {
    public int x;
    public int y;
    public GameObject prefab_grid_out_of_the_map;

	// Use this for initialization
	void Start () {

		Vector3 v_grid = new Vector3();
		float i, j;


		for(i = -7; i <= 7; i++){
			for(j = -4; j <= 4; j++){
				if( (i < -x/2 || i > x/2) || (j < -y/2 || j > y/2) ){
					v_grid.Set(i*1.25f, j*1.25f, 0);
			    
			    	GameObject.Instantiate(prefab_grid_out_of_the_map, v_grid, transform.rotation);
			    }
	    	}
    	}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
