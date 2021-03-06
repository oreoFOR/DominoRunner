﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI gemCounter;
    public TextMeshProUGUI levelNum;
    public GameObject[] startUi;

    private void Start()
    {
        levelNum.text = "Level " + (PlayerPrefs.GetInt("LevelNum") + 1).ToString();
        SetSave();
    }
    public void StartGame()
    {
        for (int i = 0; i < startUi.Length; i++)
        {
            startUi[i].SetActive(false);
        }
    }
    public void UpdateUi(int gems)
    {
        gemCounter.text = gems.ToString();
    }
    void SetSave()
    {
        PlayerPrefs.SetInt("GemNum", 0);
        gemCounter.text = "0";
        levelNum.text = "Level 10";
    }
}
