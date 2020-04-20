using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Camera MenuCamera;
    public GameObject MenuUI;
    public GameObject NewGameButton;
    public GameObject ResumeGameButton;

    public Text PersonCounter;

    public PlayerManager Player;

    public List<GameObject> LevelPeoples;

    public List<int> LevelAmounts = new List<int> {5, 10, 15, 20 };
    public int CurrentLevel;

    public GameObject AdvanceButton;
    public GameObject Wall;

    public GameObject PopupPanel;
    public GameObject TutorialPanel;
    public GameObject CreditsPanel;
    public Text Night1;

    public List<Text> Quotes;

    public void GameStart()
    {
        CurrentLevel = 0;
        TutorialPanel.SetActive(true);
        Player.CitizensRequired = LevelAmounts[CurrentLevel];
        NewGameButton.SetActive(false);
        ResumeGameButton.SetActive(true);
        MenuCamera.gameObject.SetActive(false);
        MenuUI.SetActive(false);
        PersonCounter.gameObject.SetActive(true);
        
    }

    public void EndCheck()
    {
        if (CurrentLevel == 3)
        {
            FindObjectOfType<SoundManager>().Play("Monk");
            AdvanceButton.SetActive(false);
            Wall.SetActive(false);
        }
        
    }

    public void UpdateNightPanel()
    {
        Night1.text = string.Format("Night {0}", CurrentLevel+1);
        for (int i = 0; i < Quotes.Count; i++)
        {
            if (CurrentLevel == i)
            {
                Quotes[i].gameObject.SetActive(true);
            }
            else
            {
                Quotes[i].gameObject.SetActive(false);
            }
        }
        PopupPanel.SetActive(true);
    }

    public void AdvanceNight()
    {
        LevelPeoples[CurrentLevel].SetActive(false);
        CurrentLevel++;
        Player.CitizensRequired = LevelAmounts[CurrentLevel];
        Player.UpdateObjective();
        Player.ResetPosition();
        LevelPeoples[CurrentLevel].SetActive(true);
        UpdateNightPanel();
    }

    public void EndGame()
    {
        Debug.Log("EndGame");
    }

    public void MenuOpen()
    {
        MenuUI.SetActive(true);
    }

    public void CloseMenu()
    {
        MenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BeginButton()
    {
        PopupPanel.SetActive(false);
    }

    public void TutorialQuit()
    {
        TutorialPanel.SetActive(false);
    }

    public void CreditsPanelOn()
    {
        CreditsPanel.SetActive(true);
    }

    public void CreditsPanelOff()
    {
        CreditsPanel.SetActive(false);

    }
}
