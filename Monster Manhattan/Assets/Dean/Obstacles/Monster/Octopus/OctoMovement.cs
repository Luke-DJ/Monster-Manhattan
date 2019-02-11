using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoMovement : MonoBehaviour {

    [SerializeField] private GameObject[] customTargetlocations;
    private int point;
    public bool inPosition = false;
    private float timeForSmash = 2.5f;

    // Use this for initialization
    void Start () {
        /*
         * This is a pretty cheeky way but it aint saving the objects :( 
         */
        customTargetlocations[0] = GameObject.Find("AttackPoint2");
        customTargetlocations[1] = GameObject.Find("AttackPoint4");
        customTargetlocations[2] = GameObject.Find("AttackPoint6");

        point = Random.Range(0, customTargetlocations.Length);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 target = new Vector3(customTargetlocations[point].transform.position.x, customTargetlocations[point].transform.position.y - 0.35f, customTargetlocations[point].transform.position.z);
        if (this.transform.position != target)
        {
            this.transform.position = Vector3.MoveTowards(transform.position, target, 2f * Time.deltaTime);
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
