using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Rotate(Vector3.right * Time.deltaTime * 20);
        this.gameObject.transform.Rotate(Vector3.up * Time.deltaTime * 20);
    }
}
