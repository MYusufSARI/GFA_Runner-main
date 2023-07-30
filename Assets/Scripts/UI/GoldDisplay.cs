using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;


    private void OnEnable()
    {
        GameInstance.Instance.GoldChanged += OnGoldChanged;

        UpdateUI();
    }

    private void OnDisable()
    {
        GameInstance.Instance.GoldChanged -= OnGoldChanged;
    }

    private void OnGoldChanged(int newGold)
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        UpdateUI(GameInstance.Instance.Gold);
    }


    void UpdateUI(int value)
    {
        _text.text = value.ToString();

    }
}
