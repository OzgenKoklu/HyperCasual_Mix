using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFOVAdjustment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        adjustCameraFov();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void adjustCameraFov()
    {
        float h = Display.main.systemHeight;
        float w = Display.main.systemWidth;
        float w_h = w / h;
        if (w_h >= 0.56f)
            this.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 60;
        else if (w_h <= 0.43f)
            this.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = 70;
        else
            this.gameObject.GetComponent<CinemachineVirtualCamera>().m_Lens.FieldOfView = (float)(-74.62f * (w / h) + 101.9);
    }
}
