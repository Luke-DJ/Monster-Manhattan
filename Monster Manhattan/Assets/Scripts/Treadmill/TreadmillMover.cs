using System.Collections;
using UnityEngine;

public class TreadmillMover : MonoBehaviour
{
    [SerializeField] [Tooltip("Decreases the x position of treadmill objects by this amount every second")] private float xDecrease;
    [SerializeField] [Tooltip("How many seconds before the treadmill objects start moving")] private float initialDelay;
    [SerializeField] [Tooltip("The change to the value of xDecrease every second")] private float speedIncrement;
    [SerializeField] [Tooltip("The maximum value of xDecrease")] private float maximumSpeed;
    [SerializeField] [Tooltip("The tag used by treadmill objects")] private string treadmillObjectTag;
    [HideInInspector] public bool delayActive;

    private void OnValidate()
    {
        if (xDecrease < 0)
        {
            xDecrease = 0;
        }
        if (speedIncrement < 0)
        {
            speedIncrement = 0;
        }
        if (maximumSpeed < 0)
        {
            maximumSpeed = 0;
        }
        /*if (Array.IndexOf(UnityEditorInternal.InternalEditorUtility.tags, treadmillObjectTag) < 0)
        {
            treadmillObjectTag = "";
        }*/
    }

    private void Start()
    {
        if (initialDelay > 0)
        {
            delayActive = true;
            StartCoroutine(Delay());
        }
        else
        {
            delayActive = false;
        }
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(initialDelay);
        delayActive = false;
    }

    private void Update()
    {
        if (!delayActive)
        {
            foreach (GameObject treadmillObject in GameObject.FindGameObjectsWithTag(treadmillObjectTag))
            {
                DecreaseXPosition(treadmillObject);
            }

            if (xDecrease < maximumSpeed)
            {
                xDecrease += speedIncrement * Time.fixedDeltaTime;
            }
        }
    }

    private void DecreaseXPosition(GameObject treadmillObject)
    {
        Vector3 position = treadmillObject.transform.position;
        position.x -= xDecrease * Time.deltaTime;
        treadmillObject.transform.position = position;
    }
}