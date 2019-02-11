using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWave : MonoBehaviour {
    public bool forwards; 
    
	// Update is called once per frame
	void Update () {
		if (forwards == true)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x + 0.05f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
        else
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x - 0.05f, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }
	}
}
