using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadmillSpawner : MonoBehaviour
{
    //[SerializeField] [Tooltip("The prefabs for the different treadmill object types")] private GameObject[] treadmillObjectTypes;
    [SerializeField] [Tooltip("The prefabs for the different treadmill object types")] private TreadmillObject[] treadmillObjects;
    [SerializeField] [Tooltip("The X position at which new treadmill objects will spawn from")] private float spawnPoint;
    [SerializeField] [Tooltip("The X position at which treadmill objects will be destroyed")] private float destructionPoint;
    private List<TreadmillObject> usableTreadmillObjects;
    private List<TreadmillObject> unusableTreadmillObjects;
    private ArrayList activeTreadmillObjects;
    private Bounds previousTreadmillObjectBounds;

    private void Start()
    {
        usableTreadmillObjects = new List<TreadmillObject>(treadmillObjects);
        foreach (TreadmillObject treadmillObject in usableTreadmillObjects)
        {
            treadmillObject.CalculateBounds();
        }
        unusableTreadmillObjects = new List<TreadmillObject>();
        activeTreadmillObjects = new ArrayList();

        // Continually spawning new treadmill objects next to eachother until spawnPointOverlapped is reached
        bool spawnPointOverlapped = false;
        previousTreadmillObjectBounds = new Bounds(Vector3.zero, Vector3.zero);
        while (!spawnPointOverlapped)
        {
            TreadmillObject newTreadmillObject = GetRandomTreadmillObjectType();

            Vector3 newTreadmillObjectPosition;
            if (activeTreadmillObjects.Count == 0)
            {
                newTreadmillObjectPosition = new Vector3(destructionPoint + (newTreadmillObject.bounds.center.x - newTreadmillObject.bounds.min.x), 0, 0);
                previousTreadmillObjectBounds = newTreadmillObject.bounds;
            }
            else
            {
                GameObject previousTreadmillObject = (GameObject)activeTreadmillObjects[0];
                // The X value of the new treadmill object position is the previous treadmill object's position, plus the width of the right half of the previous treadmill object, plus the left half of the new treadmill object
                newTreadmillObjectPosition = new Vector3(previousTreadmillObject.transform.position.x + previousTreadmillObjectBounds.max.x + (newTreadmillObject.bounds.center.x - newTreadmillObject.bounds.min.x) - newTreadmillObject.bounds.center.x, 0, 0);
                float sectionXRight = newTreadmillObjectPosition.x + (newTreadmillObject.bounds.center.x - newTreadmillObject.bounds.min.x);
                if (sectionXRight > spawnPoint)
                {
                    spawnPointOverlapped = true;
                }
            }

            InstantiateTreadmillObject(newTreadmillObject, newTreadmillObjectPosition);
        }
    }

    private void InstantiateTreadmillObject(TreadmillObject treadmillObjectType, Vector3 treadmillObjectPosition)
    {
        DecrementMinimumGaps();

        // Dean (Just parenting it, remove if it doesnt work)
        //activeTreadmillObjects.Insert(0, Instantiate(treadmillObjectType.prefab, treadmillObjectPosition, treadmillObjectType.prefab.transform.rotation));

        GameObject child = Instantiate(treadmillObjectType.prefab, treadmillObjectPosition, treadmillObjectType.prefab.transform.rotation);
        activeTreadmillObjects.Insert(0, child);
        child.transform.parent = this.transform;

        if (treadmillObjectType.minimumGap > 0)
        {
            unusableTreadmillObjects.Add(treadmillObjectType);
            usableTreadmillObjects.Remove(treadmillObjectType);
        }

        previousTreadmillObjectBounds = treadmillObjectType.bounds;

    }

    private void DecrementMinimumGaps()
    {
        List<TreadmillObject> temp = new List<TreadmillObject>();
        foreach (TreadmillObject treadmillObject in unusableTreadmillObjects)
        {
            treadmillObject.currentGap--;
            if (treadmillObject.currentGap <= 0)
            {
                treadmillObject.currentGap = treadmillObject.minimumGap;
                temp.Add(treadmillObject);
            }
        }

        foreach (TreadmillObject treadmillObject in temp)
        {
            unusableTreadmillObjects.Remove(treadmillObject);
            usableTreadmillObjects.Add(treadmillObject);
        }
    }

    private TreadmillObject GetRandomTreadmillObjectType()
    {
        // If there's only one usable treadmill object type, skip the random section type selection process and return the only existing usable treadmill object type
        if (usableTreadmillObjects.Count == 1)
        {
            return usableTreadmillObjects[0];
        }
        else if (usableTreadmillObjects.Count > 1)
        {
            return usableTreadmillObjects[RandomNumber.instance.GenerateExclusive(0, usableTreadmillObjects.Count)];
        }
        else
        {
            // If for some reason there aren't any usable treadmill object types, use one from the original array of treadmill object types
            if (treadmillObjects.Length == 1)
            {
                return treadmillObjects[0];
            }
            else
            {
                return treadmillObjects[RandomNumber.instance.GenerateExclusive(0, treadmillObjects.Length)];
            }
        }
    }

    private void FixedUpdate()
    {
        // Destroying the leftmost section when it has passed destructionPoint
        GameObject leftmostTreadmillObject = (GameObject)activeTreadmillObjects[activeTreadmillObjects.Count - 1];
        if (GetCalculatedBounds(leftmostTreadmillObject).max.x <= destructionPoint)
        {
            activeTreadmillObjects.RemoveAt(activeTreadmillObjects.Count - 1);
            Destroy(leftmostTreadmillObject);
        }

        // Spawning a new treadmill object when the current rightmost treadmill object has passed spawnPoint
        GameObject rightmostTreadmillObject = (GameObject)activeTreadmillObjects[0];
        float rightmostTreadmillObjectXRight = rightmostTreadmillObject.transform.position.x + previousTreadmillObjectBounds.max.x;
        if (rightmostTreadmillObjectXRight <= spawnPoint)
        {
            TreadmillObject newTreadmillObject = GetRandomTreadmillObjectType();
            Vector3 newTreadmillObjectPosition = new Vector3(rightmostTreadmillObject.transform.position.x + previousTreadmillObjectBounds.max.x + (newTreadmillObject.bounds.center.x - newTreadmillObject.bounds.min.x) - newTreadmillObject.bounds.center.x, 0, 0);
            InstantiateTreadmillObject(newTreadmillObject, newTreadmillObjectPosition);
        }
    }

    private Bounds GetCalculatedBounds(GameObject targetObject)
    {
        Renderer[] renderers = targetObject.GetComponentsInChildren<Renderer>();
        Bounds bounds = renderers[0].bounds;
        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate(renderer.bounds);
        }
        return bounds;
    }
}

[System.Serializable]
class TreadmillObject
{
    public GameObject prefab;
    [HideInInspector] public Bounds bounds;
    public int minimumGap;
    [HideInInspector] public int currentGap;

    public TreadmillObject(GameObject prefab, int minimumGap)
    {
        this.prefab = prefab;
        CalculateBounds();
        this.minimumGap = minimumGap;
        currentGap = minimumGap;
    }

    public void CalculateBounds()
    {
        Renderer[] renderers = prefab.GetComponentsInChildren<Renderer>();
        bounds = renderers[0].bounds;
        foreach (Renderer renderer in renderers)
        {
            bounds.Encapsulate(renderer.bounds);
        }
    }
}