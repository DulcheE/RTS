using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_ModifyMap : ScriptableObject {
	private int dim_x;
	private int dim_y;

	private Dictionary<string, GameObject> prefab_grid;

    private UnityEngine.UI.RawImage displaySelectedGrid;
	private TMP_Text displayCoord;  

    
	private GameObject selected;



	public UI_ModifyMap init(int dim_x, int dim_y, Dictionary<string, GameObject> prefab_grid , UnityEngine.UI.RawImage displaySelectedGrid, TMP_Text displayCoord){
		this.dim_x = dim_x;
		this.dim_y = dim_y;

		this.prefab_grid = prefab_grid;

        this.displaySelectedGrid = displaySelectedGrid;
        this.displaySelectedGrid.texture = this.prefab_grid["Out"].GetComponent<SpriteRenderer>().sprite.texture;

        this.displayCoord = displayCoord;


        return this;
	}



	public void update(string[,] grid){

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Select : " + Select.pos.x + " : " + Select.pos.y);
            Vector2 posMouse = Input.mousePosition;
			Vector3 posCam = Camera.main.transform.position;

			UnityEngine.Object.Destroy(this.selected);

            /*Vector3 selectedPos = MyCustomPosition.GetMouseOnMap();
			Vector2 selectedPosGrid = MyCustomPosition.GetMouseOnGrid();
			selectedPos.z = -1;*/
            
            Vector3 selectedPos = Select.get_pos();
            selectedPos.z = -1;
            Vector2 selectedPosGrid = new Vector2((int)(selectedPos.x / 1.25f), (int)(selectedPos.y / 1.25f));



            this.displaySelectedGrid.texture = this.prefab_grid["Out"].GetComponent<SpriteRenderer>().sprite.texture;
            //this.displayCoord.text = "Coord : (x.x)\nGrid :";
            this.displayCoord.text = "";

            if (selectedPosGrid.x > -1 && selectedPosGrid.x < dim_x && selectedPosGrid.y > -1 && selectedPosGrid.y < dim_y){
				this.selected = GameObject.Instantiate(prefab_grid["Selected"], selectedPos, new Quaternion(0,0,0,0));
                this.displaySelectedGrid.texture = this.prefab_grid[grid[(int)selectedPosGrid.x, (int)selectedPosGrid.y]].GetComponent<SpriteRenderer>().sprite.texture;
                this.displayCoord.text = "Coord : ( " + selectedPosGrid.x + " . " + selectedPosGrid.y + " )\nGrid : " + grid[(int)selectedPosGrid.x, (int)selectedPosGrid.y];
			}
		}
	}
}
