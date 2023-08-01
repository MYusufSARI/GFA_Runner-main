using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [SerializeField]
    private Button _restartLevel;

    private void OnEnable()
    {
        _restartLevel.onClick.AddListener(onRestartLevelButtonPressed);
    }

    private void OnDisable()
    {
        _restartLevel.onClick.RemoveListener(onRestartLevelButtonPressed);
    }

    private void onRestartLevelButtonPressed()
    {
        GameInstance.Instance.RestartLevel();
    }


}
