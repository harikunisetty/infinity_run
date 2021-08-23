using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;

    [SerializeField] Text coinsCountTxt;

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;
        coinsCountTxt.text = "CoinsCount: 00";
    }
    public void coinsCountUI()
    {
        coinsCountTxt.text = "CoinsCount: " + GameManager.Instance.Coins.ToString();
    }
}
