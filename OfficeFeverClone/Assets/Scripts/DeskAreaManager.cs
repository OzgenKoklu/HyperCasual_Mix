using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskAreaManager : MonoBehaviour
{
    public List<GameObject> paperList = new();
    public List<GameObject> moneyList = new();

    [SerializeField] Transform paperDropPoint;
    [SerializeField] Transform moneyDropPoint;
    [SerializeField] GameObject paperPrefab;
    [SerializeField] GameObject moneyPrefab;

    private void Start()
    {
        StartCoroutine(GenerateMoney());
    }
    


    IEnumerator GenerateMoney() 
    {
        while (true)
        {
            if (paperList.Count > 0)
            {
                GameObject temp = Instantiate(moneyPrefab);
                temp.transform.position = new Vector3(moneyDropPoint.position.x, ((float)moneyList.Count * 0.1f), moneyDropPoint.position.z);
                moneyList.Add(temp);
                RemoveLastPaper();
            }

            yield return new WaitForSeconds(0.5f);
        }     
    }


    public void GetPaper()
    {
        GameObject temp = Instantiate(paperPrefab);
        temp.transform.position = new Vector3(paperDropPoint.position.x,0.8f+ ((float)paperList.Count*0.05f) , paperDropPoint.position.z);
        paperList.Add(temp);
    }


    public void RemoveLastPaper()
    {
        if (paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }

}
