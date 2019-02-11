using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_Maker : MonoBehaviour {
    [SerializeField] private GameObject[] easyObjects;
    [SerializeField] private GameObject[] mediumObjects;
    [SerializeField] private GameObject[] hardObjects;
    [SerializeField] private GameObject coinMadness;
    [SerializeField] private GameObject[] mixtureObjects;

    [SerializeField] private GameObject lastObject;
    [SerializeField] private GameObject empty;
    [SerializeField] private GameObject gameManager;
    
    private void Start()
    {
        float temp = 35.42923f;
        lastObject = Instantiate(empty, new Vector3(35.42923f, 0.01f,11.96f), Quaternion.identity);
        lastObject.transform.parent = this.transform; 

        while (lastObject.transform.position.x < 100.0f)
        {
            temp += 10.01001f;
            NextObstacles(); 
        }
    }


	public void NextObstacles()
    {
        /*
         * Current Issues - Refreshes array every time its called doesnt have to, Only change if difficult changes ! 
         * 1 = easy ( Just easy ones )
         * 2 = medium ( Mixture of easy n medium )
         * 3 = hard ( Mixture of medium and hard )
         */

		float gap = gameManager.GetComponent<GameTracker> ().gap;
		int difficulty = gameManager.GetComponent<GameTracker> ().difficulty;


        int temp = 0;

        if(difficulty == 1)
        {
            mixtureObjects = new GameObject[easyObjects.Length ];
            for(int i = 0; i < easyObjects.Length; i++)
            {               
                mixtureObjects[i] = easyObjects[i];
            } 
        } 
        else if (difficulty == 2)
        {
            mixtureObjects = new GameObject[easyObjects.Length + mediumObjects.Length ];
            for (int i = 0; i < easyObjects.Length; i++)
            {
                mixtureObjects[i] = easyObjects[i];
            }
            for (int i = easyObjects.Length; i < mediumObjects.Length + easyObjects.Length; i++)
            {
                mixtureObjects[i] = mediumObjects[temp];
                temp++;
            } 
        }
        else
        {
            mixtureObjects = new GameObject[mediumObjects.Length + hardObjects.Length ]; 
            for (int i = 0; i < mediumObjects.Length; i++)
            {
                mixtureObjects[i] = mediumObjects[i];
            }
            for (int i = mediumObjects.Length; i < mediumObjects.Length + hardObjects.Length; i++)
            {
                mixtureObjects[i] = hardObjects[temp];
                temp++;
            } 
        }

		Vector3 vectorTemp = new Vector3((lastObject.transform.position.x +20.01001f + gap), lastObject.transform.position.y, lastObject.transform.position.z);
        
		int randomNumber = RandomNumber.instance.GenerateExclusive (0, 20); // FOR GOLDEN ROOM 1 in 20 
		if (randomNumber == 0) {
			lastObject = Instantiate(coinMadness, vectorTemp, Quaternion.identity); 
		}
		else
        {
            lastObject = Instantiate(mixtureObjects[RandomNumber.instance.GenerateExclusive(0, mixtureObjects.Length)], vectorTemp, Quaternion.identity);
        } 
        lastObject.transform.parent = this.transform;
    }
} 