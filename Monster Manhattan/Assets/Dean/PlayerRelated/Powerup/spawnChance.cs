using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnChance : MonoBehaviour {
    public GameObject powerup;
    [Range(1,100)] public int spawnPossibility; 

	// Use this for initialization
	void Start () {
		if(RandomNumber.instance.GenerateInclusive(0,100) <= spawnPossibility) { 
        	GameObject child = Instantiate(powerup, this.transform.position, Quaternion.identity); 
       	 	child.transform.parent = this.transform;
		}
    } 
}
