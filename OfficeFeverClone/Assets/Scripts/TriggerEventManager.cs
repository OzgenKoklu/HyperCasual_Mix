using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEventManager : MonoBehaviour
{
    public delegate void OnCollectArea();
    public static event OnCollectArea OnPaperCollect;
    public PrinterManger printerManager;

    public delegate void OnDeskArea();
    public static event OnDeskArea OnPaperDrop;
    public DeskAreaManager deskAreaManager;

    public delegate void OnMoneyArea();
    public static event OnMoneyArea OnMoneyCollected;

    private bool isCollecting;
    private bool isDropping;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CollectEnum());
    } 

    IEnumerator CollectEnum()
    {
        while (true)
        {
            if (isCollecting)
            {
                OnPaperCollect();
            }
            if (isDropping)
            {
                OnPaperDrop();
            }

            yield return new WaitForSeconds(0.5f);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Money"))
        {
            OnMoneyCollected();
            Destroy(other.gameObject);
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = true;
            printerManager = other.gameObject.GetComponent<PrinterManger>();
        }
        if (other.gameObject.CompareTag("DeskArea"))
        {
            isDropping = true;
            deskAreaManager = other.gameObject.GetComponent<DeskAreaManager>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("CollectArea"))
        {
            isCollecting = false;
            printerManager = null;
        }
        if (other.gameObject.CompareTag("DeskArea"))
        {
            isDropping = false;
            deskAreaManager = null;
        }
    }
}
