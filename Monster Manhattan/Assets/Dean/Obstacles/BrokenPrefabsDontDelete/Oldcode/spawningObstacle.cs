using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawningObstacle : MonoBehaviour {

    /*
     * OLD CODE
     */
    
    public int difficulty = 1;

    public GameObject[] Pave1;
    public GameObject[] Pave2;

    public GameObject[] Obstacles;

    public string Seed= "";


    //public int[] Sequence; 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene("Default");
        }
    }

    private void Start()
    {
        //SequenceMaker(difficulty);  





        for (int i = 0; i < Pave1.Length; i++)
        {
            int chance = Random.Range(0, difficulty + 1);
            int type = Random.Range(0, Obstacles.Length);

            if (chance != difficulty)
            {
                obstacleCreation(i, 1, type);
            } 

            chance = Random.Range(0, difficulty + 1);
            int type2 = Random.Range(0, Obstacles.Length);

            while (type == 3 && type2 == 3)// 3 = WALL
            {
                type2 = Random.Range(0, Obstacles.Length);
            }

            if (chance != difficulty)
            {
                obstacleCreation(i,2, type2);
            }

            Seed += type.ToString();

            Seed += type2.ToString();
        }
    }

    void obstacleCreation(int pos, int lane, int type)
    {
        if (lane == 1)
        {
            Instantiate(Obstacles[type], new Vector3(Pave1[pos].transform.position.x, Pave1[pos].transform.position.y + .4f, Pave1[pos].transform.position.z), Quaternion.identity);
        } else { 
            Instantiate(Obstacles[type], new Vector3(Pave2[pos].transform.position.x, Pave2[pos].transform.position.y + .4f, Pave2[pos].transform.position.z), Quaternion.identity);
        }
    } 

    public void newSegment(GameObject segment1, GameObject segment2)
    {
        int chance = Random.Range(0, difficulty + 1);
        int type = Random.Range(0, Obstacles.Length);

        if (chance != difficulty)
        {
            Instantiate(Obstacles[type], new Vector3(segment1.transform.position.x, segment1.transform.position.y + .4f, segment1.transform.position.z), Quaternion.identity);          
        }

        chance = Random.Range(0, difficulty + 1);
        int type2 = Random.Range(0, Obstacles.Length);

        while (type == 3 && type2 == 3)// 3 = WALL
        {
            type2 = Random.Range(0, Obstacles.Length);
        }

        if (chance != difficulty)
        {
            Instantiate(Obstacles[type], new Vector3(segment2.transform.position.x, segment2.transform.position.y + .4f, segment2.transform.position.z), Quaternion.identity);
        }

        Seed += type.ToString();

        Seed += type2.ToString();
    }
}
