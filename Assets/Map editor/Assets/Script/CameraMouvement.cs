using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouvement : ScriptableObject {
	public float camera_sensibility;
	public float camera_speed;

	private int dim_x;
	private int dim_y;

	private Vector2 posMouse;
	private float posCamMin_x;
	private float posCamMin_y;
	private float posCamMax_x;
	private float posCamMax_y;



	public CameraMouvement init(int adim_x, int adim_y, float acamera_sensibility, float acamera_speed){
		this.dim_x = adim_x;
		this.dim_y = adim_y;
		this.camera_sensibility = acamera_sensibility;
		this.camera_speed = acamera_speed;


        posCamMin_x = 11.09723f - (11.09723f - 11.09723f / (16f / 9f) * Camera.main.aspect);
        posCamMin_y = 4.875f - (4.875f - 4.875f / (16f / 9f) * Camera.main.aspect);
        posCamMin_x = 11.09723f / (16f / 9f) * Camera.main.aspect;
        posCamMin_y = 0.875f / (16f / 9f) * Camera.main.aspect;


        this.posCamMax_x = posCamMin_x;
		this.posCamMax_y = posCamMin_y;

        Camera.main.transform.position = new Vector3(this.posCamMin_x, this.posCamMin_y, Camera.main.transform.position.z);

        if(this.dim_x > Camera.main.orthographicSize*2*Camera.main.aspect/1.25f - 4)
			this.posCamMax_x = ((float)this.dim_x - (Camera.main.orthographicSize*2*Camera.main.aspect/1.25f - 4))*1.25f + posCamMin_x;
		if(this.dim_y > Camera.main.orthographicSize*2/1.25f - 4)
			this.posCamMax_y = (float)(this.dim_y - (Camera.main.orthographicSize*2/1.25f - 4))*1.25f + posCamMin_y;


		return this;
	}



	public void update(){
		this.posMouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

		float screen_move = Screen.width * this.camera_sensibility;

		if( (this.posMouse.x < screen_move) && (Camera.main.transform.position.x > this.posCamMin_x) ){
			//On décale vers la gauche
			float speed = (screen_move - this.posMouse.x) / screen_move;
			if(speed > 1)
				speed = 1;

			Vector3 move = new Vector3(-this.camera_speed * speed, 0, 0);

			Camera.main.transform.Translate(move, Space.World);

			if(Camera.main.transform.position.x < this.posCamMin_x){
				Camera.main.transform.position = new Vector3(this.posCamMin_x, Camera.main.transform.position.y, Camera.main.transform.position.z);
			}

		}else if( (this.posMouse.x > Screen.width - screen_move) && (Camera.main.transform.position.x < this.posCamMax_x) ){
			//On décale vers la droite
			float speed = (this.posMouse.x - Screen.width + screen_move) / screen_move;
			if(speed > 1)
				speed = 1;

			Vector3 move = new Vector3(this.camera_speed * speed, 0, 0);

			Camera.main.transform.Translate(move, Space.World);

			if(Camera.main.transform.position.x > this.posCamMax_x){
				Camera.main.transform.position = new Vector3(this.posCamMax_x, Camera.main.transform.position.y, Camera.main.transform.position.z);
			}

		}if( (this.posMouse.y < screen_move/4) && (Camera.main.transform.position.y > posCamMin_y) ){
			//On décale vers le bas
			float speed = (screen_move/4 - this.posMouse.y) / (screen_move/4);
			if(speed > 1)
				speed = 1;

			Vector3 move = new Vector3(0, -this.camera_speed * speed, 0);

			Camera.main.transform.Translate(move, Space.World);

			if(Camera.main.transform.position.y < posCamMin_y){
				Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, posCamMin_y, Camera.main.transform.position.z);
			}

		}else if( (this.posMouse.y > Screen.height - screen_move) && (Camera.main.transform.position.y < this.posCamMax_y) ){
			//On décale vers le haut
			float speed = (this.posMouse.y - Screen.height + screen_move) / screen_move;
			if(speed > 1)
				speed = 1;

			Vector3 move = new Vector3(0, this.camera_speed * speed, 0);

			Camera.main.transform.Translate(move, Space.World);

			if(Camera.main.transform.position.y > this.posCamMax_y){
				Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, this.posCamMax_y, Camera.main.transform.position.z);
			}

		}
	}
} 