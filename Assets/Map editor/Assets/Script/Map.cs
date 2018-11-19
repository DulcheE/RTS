using System; 
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : ScriptableObject{
	private string map_dir;
    private Dictionary<string, GameObject> prefab_grid;

	private int dim_x;
	private int dim_y;

	private string[,] grid;

	private const float defaultPos_x = 11.09723f;
	private const float defaultPos_y = 4.875f;
	private GameObject selected;



	public int get_dim_x(){
		return this.dim_x;
	}

	public int get_dim_y(){
		return this.dim_y;
	}



	public Map init(string amap_dir, Dictionary<string, GameObject> prefab_grid){
		this.map_dir = amap_dir;
        this.prefab_grid = prefab_grid;


		return this;
	}



	public string[,] read(){
		string[] lines = System.IO.File.ReadAllLines("./Assets/" + map_dir + ".mapmeta");


		this.dim_x = Convert.ToInt32(lines[0]);
		this.dim_y = Convert.ToInt32(lines[1]); 

		this.grid = new string[this.dim_x, this.dim_y];

		lines = System.IO.File.ReadAllLines("./Assets/" + map_dir + ".mapdata");

		for(int i = 0; i < this.dim_y; i++){
			string[] line = Regex.Split(lines[i], ",");
			for(int j = 0; j < this.dim_x; j++){
				this.grid[j,i] = line[j];
			}
		}


		return grid;
	}


	public void display(){

		Vector3 v_grid = new Vector3();
		Quaternion q_grid = new Quaternion(0f, 0f, 0f, 0f);
		int i, j;


		for(i = 0; i < this.dim_x; i++){
			for(j = 0; j < this.dim_y; j++){
				v_grid.Set((float)i*1.25f, (float)j*1.25f, 0);
                
				GameObject.Instantiate(prefab_grid[grid[i, j]], v_grid, q_grid);
		    }
    	}



    	int max_x = dim_x + 2;
    	int max_y = dim_y + 2;

    	if(max_x < 13)
    		max_x = 13;
    	if(max_y < 6)
    		max_y = 6;

		for(i = -2; i < max_x; i++){
			for(j = -2; j < max_y; j++){
				if( (i < 0 || i >= this.dim_x) || (j < 0 || j >= this.dim_y) ){
					v_grid.Set(i*1.25f, j*1.25f, 0);
			    
			    	GameObject.Instantiate(prefab_grid["Out"], v_grid, q_grid);
			    }
	    	}
    	}

	}


}
