using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI gemCounter;
    public void UpdateUi(int gems)
    {
        gemCounter.text = gems.ToString();
    }
}
