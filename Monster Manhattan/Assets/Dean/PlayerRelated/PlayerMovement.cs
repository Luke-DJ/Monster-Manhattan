using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /*
     * Simple lane teleporting lane swapping
     */ 
	public GameObject[] forwards;

	public GameObject[] backwards;
 
    public int currentLane = 0; 
	public int currentpos = 1; 

    // Use this for initialization
	void Start () {
		Vector3 pos = new Vector3 (forwards [currentpos].transform.position.x, 1.32f, forwards [currentpos].transform.position.z);
		this.gameObject.transform.position = pos;
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.D))
		{
			if (currentLane == 0)
			{
				currentLane = 1;
			} 
		}
		if (Input.GetKeyDown(KeyCode.A))
		{
			if (currentLane == 1)
			{
				currentLane = 0;
			} 
		}
 

		if (Input.GetKeyDown(KeyCode.W)){
			currentpos++;
			if(currentpos >2){
				currentpos = 2;
			}
		}
		if (Input.GetKeyDown(KeyCode.S)){
			currentpos--;
			if(currentpos < 0){
				currentpos = 0;
			}
		}
		Vector3 pos;
		if (currentLane == 0) {
			pos = new Vector3 (forwards [currentpos].transform.position.x, 1.32f, forwards [currentpos].transform.position.z);
		}
		else
		{
			pos = new Vector3 (backwards [currentpos].transform.position.x, 1.32f, backwards [currentpos].transform.position.z);
		}
		this.gameObject.transform.position = pos; 
    }
}
