using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour {

    Animator animator;






    Animator m_Animator;
    string m_ClipName;
    AnimatorClipInfo[] m_CurrentClipInfo;

    float m_CurrentClipLength;

    // Use this for initialization
    void Start () {
        //Get the Animator
        animator = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        //Temp Key Inputs

        //Trigger for Run
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.SetTrigger("Run");
        }

        //Trigger for Slide
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Slide");
        }

        //Trigger for Jump
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Jump");
        }

        //Trigger for Game Over
        if (Input.GetKeyDown(KeyCode.R))
        {
            animator.SetTrigger("GameOver");
        }


        //Get them_Animator, which you attach to the GameObject you intend to animate.
        m_Animator = gameObject.GetComponent<Animator>();
        //Fetch the current Animation clip information for the base layer
        m_CurrentClipInfo = this.m_Animator.GetCurrentAnimatorClipInfo(0);
        //Access the current length of the clip
        m_CurrentClipLength = m_CurrentClipInfo[0].clip.length;
        //Access the Animation clip name
        m_ClipName = m_CurrentClipInfo[0].clip.name;


    }


    void OnGUI()
    {
        //Output the current Animation name and length to the screen
        GUI.Label(new Rect(0, 0, 200, 20), "Clip Name : " + m_ClipName);
        GUI.Label(new Rect(0, 30, 200, 20), "Clip Length : " + m_CurrentClipLength);
    }
}
