using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ZoomOnPoint : MonoBehaviour
{
    public Animator animatorCineMachine;
    public float minZoom;
    public float maxZoom;
    public float ratioZoom;
    public float valueRatioZoom;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    bool temp1;
    bool temp2;
    void Awake()
    {
        MakeZoom();
        temp1 = false;
        temp2 = false;
    }

    private void OnEnable()
    {
        ThrowController.Onslow += MakeZoom;
    }

    private void OnDisable()
    {
        ThrowController.Onslow -= MakeZoom;
    }



    public void MakeZoom()
    {
        StopAllCoroutines();
        if (ThrowController.isSlow)
        {
            temp1 = true;
            StartCoroutine(ZoomOut());
        }

        else
        {
            temp2 = true;
            
            StartCoroutine(ZoomIn());
        }
    }


    IEnumerator ZoomOut()
    {

        while (cinemachineVirtualCamera.m_Lens.OrthographicSize < minZoom)
        {
            yield return new WaitForSecondsRealtime(ratioZoom);
            cinemachineVirtualCamera.m_Lens.OrthographicSize += valueRatioZoom;

        }

        if (cinemachineVirtualCamera.m_Lens.OrthographicSize >= minZoom)
        {
            temp1 = false;
        }


        yield return null;
    }

    IEnumerator ZoomIn()
    {
        
        while (cinemachineVirtualCamera.m_Lens.OrthographicSize > maxZoom)
        {
            yield return new WaitForSecondsRealtime(ratioZoom);
            cinemachineVirtualCamera.m_Lens.OrthographicSize -= valueRatioZoom;
            
        }

        if(cinemachineVirtualCamera.m_Lens.OrthographicSize <= maxZoom)
        {
            temp2 = false;
        }

        yield return null;
    }



}
