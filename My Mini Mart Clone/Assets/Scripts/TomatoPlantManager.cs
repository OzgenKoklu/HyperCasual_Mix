using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomatoPlantManager : MonoBehaviour
{
    public List<GameObject> tomatoesReadyToCollectList = new List<GameObject>();
    public GameObject[] tomatoes;
    bool inPickingPhase;
    [SerializeField] Collider PlantBodyCollider;
    [SerializeField] StackManager stackManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewTomatoes());
    }

    private void Update()
    {
        
    }

    //IENumerator bir logic içine alýnsa veya event ile triggerlansa daha optimize olabilir. 
    IEnumerator SpawnNewTomatoes()
    {
        Debug.Log("Spawn New started");
        while (tomatoes[2].activeSelf == false && !inPickingPhase)
        {
                for (int i = 0; i < tomatoes.Length; i++)
                {
                    if (tomatoes[i].activeSelf == false)
                    {
                    yield return new WaitForSeconds(1);
                    tomatoes[i].SetActive(true);
                    }

                }
      
        }
        Debug.Log("Spawn New stopped");
        //yield return new WaitForSeconds(1);

    }

   private void OnTriggerEnter(Collider other)
    {
       inPickingPhase = true;
       StartCoroutine(pullTomatoes());
    }

    private void OnTriggerExit(Collider other)
    {
        inPickingPhase = false;
        StartCoroutine(SpawnNewTomatoes());
    }

    IEnumerator pullTomatoes()
    {
            for (int i = tomatoes.Length -1; i >= 0; i--)
            {
                if (inPickingPhase)
                {
                    tomatoes[i].SetActive(false);
                    stackManager.addToStack(tomatoes[i].gameObject, tomatoes[i].transform);
                    yield return new WaitForSeconds(0.5f);
                }             
            }
                  
    }
}

