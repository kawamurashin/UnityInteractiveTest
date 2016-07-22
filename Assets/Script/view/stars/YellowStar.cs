using UnityEngine;
using System.Collections;

public class YellowStar : MovieClip {
    public delegate void CallBack(YellowStar star);
    private CallBack onMouseDown;
    private CallBack onMouseDrag;
    private CallBack onMouseUP;
    public Vector3 offset;
    public float vx = 0;
    public float vy = 0;
    public void addMouseDown(CallBack callback)
    {
        onMouseDown += callback;
    }
    public void addMouseDrag(CallBack callback)
    {
        onMouseDrag += callback;
    }
    public void addMouseUp(CallBack callback)
    {
        onMouseUP += callback;
    }
    void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        onMouseDown(this);
    }
    void OnMouseDrag()
    {
        onMouseDrag(this);
    }
    void OnMouseUp()
    {
        onMouseUP(this);
    }

    // Use this for initialization
    void Start()
    {

    }
	// Update is called once per frame
	void Update () {
	
	}
}
