using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Editor : MonoBehaviour
{
    [SerializeField]
    private string[] prefab_grid_name;
    [SerializeField]
    private GameObject[] prefab_grid_sprite;
    Dictionary<string, GameObject> prefab_grid;


    [SerializeField]
    private TMP_Text displayCoord;
    [SerializeField]
    private UnityEngine.UI.RawImage displaySelectedGrid;


    private Map map;
	private string[,] grid;


	private CameraMouvement camMou;
    [SerializeField]
    private float camera_sensibility;
    [SerializeField]
    private float camera_speed;


	private UI_ModifyMap UI_1; 



	// Use this for initialization
	void Start () {

        this.prefab_grid = new Dictionary<string, GameObject>();

        for(int i = 0; i < prefab_grid_name.Length; i++)
        {
            prefab_grid[prefab_grid_name[i]] = prefab_grid_sprite[i];
            Debug.Log(prefab_grid_name[i]);
        }


		this.map = ScriptableObject.CreateInstance<Map>().init("Map/Map_test/Map_test_01", this.prefab_grid);


		this.grid = this.map.read();


		this.camMou = ScriptableObject.CreateInstance<CameraMouvement>().init(this.map.get_dim_x(), this.map.get_dim_y(), this.camera_sensibility, this.camera_speed);

		this.UI_1 = ScriptableObject.CreateInstance<UI_ModifyMap>().init(this.map.get_dim_x(), this.map.get_dim_y(), this.prefab_grid, this.displaySelectedGrid, this.displayCoord);


		this.map.display();
		
	}
	
	// Update is called once per frame
	void Update () {
		this.camMou.update();
		this.UI_1.update(this.grid);
	}
}
