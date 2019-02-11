using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawning : MonoBehaviour {

    public int difficulty;
    public GameObject[] nodes;
    public GameObject[] Obstacles;
    public GameObject manager;
    int lastone; 
    // Use this for initialization
    void Start () { 
        
        manager = GameObject.Find("GameManager");
        difficulty = manager.GetComponent<Manager>().difficulty;
        difficulty = difficulty * 10;
         
    
		for(int i = 0; i < (nodes.Length); i++) // Does two nodes at time 
        {
            int chance = Random.Range(0, 100);
            int type = Random.Range(0, Obstacles.Length); // Type of obstacle

            while (type == 2 && lastone == 2) //3 = wall
            {
                type = Random.Range(0, Obstacles.Length); // Type of obstacle
            }
            if (chance < difficulty)
            {
                GameObject child = Instantiate(Obstacles[type], new Vector3(nodes[i].transform.position.x, nodes[i].transform.position.y, nodes[i].transform.position.z), Quaternion.identity);
                child.transform.parent = this.transform;
            } 
            lastone = type; 
        }
	} 
}
