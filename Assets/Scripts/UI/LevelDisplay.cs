using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;


    private void OnEnable()
    {
        GameInstance.Instance.LevelChanged += OnLevelChanged;

        UpdateUI();
    }

    private void OnDisable()
    {
        GameInstance.Instance.LevelChanged -= OnLevelChanged;
    }

    private void OnLevelChanged(int newLevel)
    {
        UpdateUI(newLevel);
    }

    private void UpdateUI()
    {
        UpdateUI(GameInstance.Instance.Level);
    }


    void UpdateUI(int value)
    {
        _text.text = "Level: " + (value + 1);

    }
}
