using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    

    void Update()
    {
        _text.text = GameInstance.Instance.Gold.ToString();

    }
}
