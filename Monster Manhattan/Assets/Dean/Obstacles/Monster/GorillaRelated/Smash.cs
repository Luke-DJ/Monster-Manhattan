using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smash : MonoBehaviour {
    [SerializeField] private GameObject shockwave;
    [SerializeField] private GameObject mainParent;
    [SerializeField] private GameObject shadow;
    [SerializeField] private Transform[] children;
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 scale;

    private bool hit = false;
    private bool once = true;
    private bool position = false;
    private float timer = 1f;
    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }
    void Update () { 
        position = mainParent.GetComponent<MonsterMovement>().inPosition;
        if(position == true && this.gameObject.transform.position.y > 0f)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.25f, this.gameObject.transform.position.z);
             
            scale = new Vector3(shadow.gameObject.transform.localScale.x, shadow.gameObject.transform.localScale.y, shadow.gameObject.transform.localScale.z);
 
            if (shadow.gameObject.transform.localScale.x < 1.72052f)
            {
                scale.x += 0.04f;
            }

            if (shadow.gameObject.transform.localScale.y < 7.097186f)
            {
                scale.y += 0.05f;
            } 

            shadow.gameObject.transform.localScale = scale;
        }
        else if(position == true)
        {
            hit = true;
            timer -= Time.deltaTime;
        } 

        if(timer < 0)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.5f, this.gameObject.transform.position.z);
            scale = new Vector3(shadow.gameObject.transform.localScale.x, shadow.gameObject.transform.localScale.y, shadow.gameObject.transform.localScale.z);
            
            scale.x -= 0.08f;
            scale.y -= 0.1f;

            if(scale.x <0 || scale.y < 0)
            {
                scale = Vector3.zero;
            }

            shadow.gameObject.transform.localScale = scale;

            if (this.gameObject.transform.position.y > 8){
                GameObject.Destroy(mainParent);
            }
        }

        if (hit == true && once == true)
        {
            cam.GetComponent<SmoothCamera>().shake = true;
            GameObject child = Instantiate(shockwave, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.175f, this.gameObject.transform.position.z), Quaternion.identity);
            child.GetComponent<ShockWave>().forwards = false;
            child.transform.parent = mainParent.transform;

            child = Instantiate(shockwave, new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.175f, this.gameObject.transform.position.z), Quaternion.identity);
            child.GetComponent<ShockWave>().forwards = true;
            child.transform.parent = mainParent.transform; 
            once = false;
        }
    }
}
