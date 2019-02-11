using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackCoin : MonoBehaviour {

	public GameObject GameManager;
    public bool isActivated = false;
    public float timer = 10f;

    float originalLocation;

    // Use this for initialization
	void Start () {
		GameManager = GameObject.Find ("GameManager");
        originalLocation = this.gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            isActivated = false;
        }

        if (isActivated == true)
        {
            Vector3 target = new Vector3(this.gameObject.transform.position.x, 6f, this.gameObject.transform.position.z);
            this.transform.position = Vector3.MoveTowards(transform.position, target, 3.0f * Time.deltaTime);
        }
        else
        {
            Vector3 target = new Vector3(this.gameObject.transform.position.x, originalLocation, this.gameObject.transform.position.z);
            this.transform.position = Vector3.MoveTowards(transform.position, target, 1.0f * Time.deltaTime);
        } 
	}
}
