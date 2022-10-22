using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject currentMenu;

    public void changeCurrentMenu(GameObject menu)
    {
        currentMenu.SetActive(false);
        currentMenu = menu;
        currentMenu.SetActive(true);
    }

    public void changeScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void closeGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }


    #region debug

    public void completeLevel1()
    {
        PlayerPrefs.SetInt("Level1Completed", 1);
    }
    public void completeLevel2()
    {
        PlayerPrefs.SetInt("Level2Completed", 1);
    }

    public void resetLvls()
    {
        PlayerPrefs.SetInt("Level2Completed", 0);
        PlayerPrefs.SetInt("Level1Completed", 0);

    }


    #endregion
}
