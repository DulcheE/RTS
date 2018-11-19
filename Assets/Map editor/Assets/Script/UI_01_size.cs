using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_01_size : MonoBehaviour
{
    private RectTransform myRectTransform;
    [SerializeField]
    private float ax;
    [SerializeField]
    private float ay;
    [SerializeField]
    private int bx;
    [SerializeField]
    private int by;
    [SerializeField]
    private bool aspectRatio;



    private void Start()
    {
        this.myRectTransform = GetComponent<RectTransform>();
    }

    // Use this for initialization
    void Update () {
		Vector2 v = new Vector2();
        

		if(aspectRatio)
			v.y = Screen.height*ay + by;
		else
			v.y = Screen.width*ay +by;
		v.x = Screen.width*ax + bx;
		

		this.myRectTransform.sizeDelta = v;
	}
}
