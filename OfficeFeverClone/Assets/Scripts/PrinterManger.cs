using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterManger : MonoBehaviour
{
    public List<GameObject> paperList = new();
    [SerializeField] GameObject paperPrefab;
    [SerializeField] Transform exitPoint;
    private bool isWorking;
    private int stackCount = 10;

    void Start()
    {
        StartCoroutine(PrintPaper());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveLastPaper()
    {
        if(paperList.Count > 0)
        {
            Destroy(paperList[paperList.Count - 1]);
            paperList.RemoveAt(paperList.Count - 1);
        }
    }

    IEnumerator PrintPaper()
    {
        while (true)
        {
            int rowCount = paperList.Count / stackCount; 
            if (isWorking)
            {
                GameObject temp = Instantiate(paperPrefab);
                temp.transform.position = new Vector3(exitPoint.transform.position.x +(float)rowCount/3, (paperList.Count%stackCount)*0.05f, exitPoint.transform.position.z);
                // Debug.Log((float)paperList.Count * 0.05f);
                paperList.Add(temp);
            }
          
            if(paperList.Count >= 30)
            {
                isWorking = false;
            }else
            {
                isWorking = true;
            }
            yield return new WaitForSeconds(1);
        }
    }
}
