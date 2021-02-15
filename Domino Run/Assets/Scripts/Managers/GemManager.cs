using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour
{
    int gemNum;
    public UiManager uiManager;
    private void Start()
    {
        gemNum = PlayerPrefs.GetInt("GemNum");
        uiManager.UpdateUi(gemNum);
    }
    public void IncrementGems()
    {
        gemNum += 1;
        uiManager.UpdateUi(gemNum);
    }
    public void SaveGems()
    {
        PlayerPrefs.SetInt("GemNum", gemNum);
    }
}
