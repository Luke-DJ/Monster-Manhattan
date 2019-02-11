using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctoSmash : MonoBehaviour {
    [SerializeField] private GameObject shadow;
    [SerializeField] private GameObject mainParent;
    private bool position = false;
    private float timer = 1.5f;
    private bool once = false;
    private Camera cam;

    private void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    void Update () {
        position = mainParent.GetComponent<OctoMovement>().inPosition;
        if (position == true && this.gameObject.transform.position.y > 0.5f)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - 0.25f, this.gameObject.transform.position.z);

            Vector3 scale = new Vector3(shadow.gameObject.transform.localScale.x, shadow.gameObject.transform.localScale.y, shadow.gameObject.transform.localScale.z);

            if (shadow.gameObject.transform.localScale.y < 1)
            {
                scale.x += 0.0025f;
            }

            if (shadow.gameObject.transform.localScale.y < 1)
            {
                scale.y += 0.0025f;
            }

            shadow.gameObject.transform.localScale = scale;


        }
        else if (position == true)
        {
            if(once == false)
            {
                cam.GetComponent<SmoothCamera>().shake = true;
                once = true;
            }
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {
			this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.5f, this.gameObject.transform.position.z);
            if (this.gameObject.transform.position.y > 5)
            {
                GameObject.Destroy(mainParent);
            }
        }
    }
}
