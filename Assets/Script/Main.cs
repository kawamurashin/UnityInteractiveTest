using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject gameObject = Instantiate(Resources.Load("prefab/ViewManager")) as GameObject;
        ViewManager viewManager = gameObject.GetComponent<ViewManager>();
    }
	
	// Update is called once per frame
	void Update () {
        //Vector3 mousePosition = Input.mousePosition;
        //Debug.Log(mousePosition);
	}

}
