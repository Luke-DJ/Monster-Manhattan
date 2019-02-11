using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public bool shake; // Just turn this on to shake
    public float duration; 
    float temp;
    public Vector3 originalPos;
    private void Start()
    {
        originalPos = transform.position;
        temp = duration;
    }
    private void Update()
    {
        if (shake == true)
        {
            if (duration > 0)
            {
                duration -= Time.deltaTime;
                transform.position += Random.insideUnitSphere / 3;
            }
            else
            {
                transform.position = originalPos;
                duration = temp;
                shake = false;
            }
        }
    } 
}