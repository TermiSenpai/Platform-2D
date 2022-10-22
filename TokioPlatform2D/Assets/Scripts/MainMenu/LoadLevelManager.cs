using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevelManager : MonoBehaviour
{
    [SerializeField] private Button lvl2Btn;
    [SerializeField] private Button lvl3Btn;

    private void OnEnable()
    {
        int lvl1Completed = PlayerPrefs.GetInt("Level1Completed", 0);
        int lvl2Completed = PlayerPrefs.GetInt("Level2Completed", 0);

        if (lvl1Completed.Equals(1))
            lvl2Btn.interactable = true;
        if (lvl2Completed.Equals(1))
            lvl3Btn.interactable = true;

    }
}
