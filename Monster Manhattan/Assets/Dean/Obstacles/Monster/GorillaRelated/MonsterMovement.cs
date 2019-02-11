using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour {
    [SerializeField] private GameObject[] targetlocations;
    public bool inPosition = false;
    private float timeForSmash = 3f;
    private int point;

    private void Start()
    {
        targetlocations = GameObject.FindGameObjectsWithTag("attackpoint");
        point = Random.Range(0, targetlocations.Length);         
    }


    void Update () {
        if (this.transform.position != targetlocations[point].transform.position)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, targetlocations[point].transform.position, 2.0f * Time.deltaTime);
        }
        else
        {
            timeForSmash -= Time.deltaTime;
            if (timeForSmash < 0)
            {
                inPosition = true;
            }
        }
    }
}
