using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    public List<GameObject> paperList = new();
    [SerializeField] GameObject paperPrefab;
    [SerializeField] Transform collectionPoint;
    [SerializeField] TriggerEventManager triggerEventManager;

    private int paperLimit = 10;

    private void OnEnable()
    {
        TriggerEventManager.OnPaperCollect += GetPaper;
        TriggerEventManager.OnPaperDrop += GivePaper;
    }

    private void OnDisable()
    {
        TriggerEventManager.OnPaperCollect -= GetPaper;
        TriggerEventManager.OnPaperDrop -= GivePaper;
    }



    void GetPaper()
    {
        if(paperList.Count <= paperLimit)
        {
            GameObject temp = Instantiate(paperPrefab, collectionPoint);
            temp.transform.position = new Vector3(collectionPoint.position.x, 0.5f + ((float)paperList.Count*0.05f), collectionPoint.position.z);
            paperList.Add(temp);
            if(triggerEventManager.printerManager != null)
            {
                triggerEventManager.printerManager.RemoveLastPaper();
            }
        }
    }

    void GivePaper()
    {
        if(paperList.Count > 0)
        {
            triggerEventManager.deskAreaManager.GetPaper();
            RemoveLastPaper();
        }


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
