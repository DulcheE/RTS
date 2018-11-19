using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyCustomPosition {

	private static Vector2 posMouse;
	private static Vector3 posCam;

	private const float defaultPos_x = 11.09723f;
	private const float defaultPos_y = 4.875f;



	public static Vector2 GetMouseOnScreen(){
		posMouse = Input.mousePosition;
		posCam = Camera.main.transform.position;
		

		return new Vector2(posMouse.x/Screen.width*Camera.main.orthographicSize*200 * Camera.main.aspect, posMouse.y/Screen.height*Camera.main.orthographicSize*200);
	}

	public static Vector2 GetMouseOnSpace(){
		posMouse = Input.mousePosition;
		posCam = Camera.main.transform.position;

		Vector2 v = MyCustomPosition.GetMouseOnScreen();
		

		return new Vector2(v.x + (posCam.x - defaultPos_x) * 100, v.y + (posCam.y - defaultPos_y) * 100);
	}

	public static Vector2 GetMouseOnGrid(){
		posMouse = Input.mousePosition;
		posCam = Camera.main.transform.position;

		Vector2 v = MyCustomPosition.GetMouseOnSpace();
		


		return new Vector2( ((int)(v.x/ 125)-2), ((int)(v.y/ 125)-2));
	}

	public static Vector2 GetMouseOnMap(){
		posMouse = Input.mousePosition;
		posCam = Camera.main.transform.position;

		Vector2 v = MyCustomPosition.GetMouseOnGrid();


		return new Vector2( v.x*1.25f, v.y*1.25f);
	}

}
