using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DollyController : MonoBehaviour
{
    CinemachineDollyCart dollyCart;
    GameObject dollyCam;

    MainCam mainCam;

    CamDrag_Panel controlUI;
    Round_UI roundUI;

    public Action onIntroEnd;

    private void Awake()
    {
        dollyCart = GetComponent<CinemachineDollyCart>();
        dollyCam = GameObject.Find("DollyCam");

        mainCam = FindObjectOfType<MainCam>(true);

        controlUI = FindObjectOfType<CamDrag_Panel>();
        roundUI = FindObjectOfType<Round_UI>();
    }

    public void InitializeIntroUIs()
    {
        dollyCart.m_Position = 0f;
        GameManager.Inst.Player_Stats.gameObject.SetActive(false);
        controlUI.transform.parent.gameObject.SetActive(false);
        roundUI.gameObject.SetActive(false);

        StartCoroutine(Intro());
    }

    IEnumerator Intro()
    {
        while (true)
        {
            if (dollyCart.m_Position >= dollyCart.m_Path.PathLength)
            {
                dollyCam.SetActive(false);
                mainCam.gameObject.SetActive(true);
                GameManager.Inst.Player_Stats.gameObject.SetActive(true);
                controlUI.transform.parent.gameObject.SetActive(true);
                roundUI.gameObject.SetActive(true);

                onIntroEnd?.Invoke();
                break;
            }
            yield return null;
        }
    }
}