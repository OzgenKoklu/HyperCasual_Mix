using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    [SerializeField] Transform playerStackTransform;
    [SerializeField] List<GameObject> stackedObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addToStack(GameObject objectToCollect, Transform collectedObjectsTransform)
    {
        GameObject collectedObject = Instantiate(objectToCollect, collectedObjectsTransform.position, collectedObjectsTransform.rotation);
        stackedObjects.Add(collectedObject);
        collectedObject.SetActive(true);
        collectedObject.transform.localScale *= 3;
        StartCoroutine(lerpcollectedToPlayerLocation(collectedObject));
        // Debug.Log("Added to stack." + objectToCollect.name + " " + collectedObjectsTransform.ToString());
    }

    IEnumerator lerpcollectedToPlayerLocation(GameObject collectedObject)
    {
        while(collectedObject.transform.position.magnitude - playerStackTransform.position.magnitude >= 0.05f)
        {
            collectedObject.transform.position = Vector3.Lerp(collectedObject.transform.position, playerStackTransform.position, 10*Time.deltaTime);
            yield return null;
        }
        collectedObject.transform.SetParent(playerStackTransform);
    }
}
