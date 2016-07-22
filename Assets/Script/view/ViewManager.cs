using UnityEngine;
using System.Collections;

public class ViewManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject gameObject = Instantiate(Resources.Load("prefab/StarManager")) as GameObject;
        StarManager starManager = gameObject.GetComponent<StarManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
