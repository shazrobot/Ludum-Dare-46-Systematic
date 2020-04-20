using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Camera MenuCamera;
    public GameObject MenuUI;
    public Text PersonCounter;
    //public GameObject Level1People;
    //public GameObject Level2People;
    //public GameObject Level3People;
    //public GameObject Level4People;

    public PlayerManager Player;

    public List<GameObject> LevelPeoples;

    public List<int> LevelAmounts = new List<int> {5, 10, 15, 20 };
    public int CurrentLevel;

    public void GameStart()
    {
        CurrentLevel = 0;
        Player.CitizensRequired = LevelAmounts[CurrentLevel];
        MenuCamera.gameObject.SetActive(false);
        MenuUI.SetActive(false);
        PersonCounter.gameObject.SetActive(true);
    }

    public void AdvanceNight()
    {
        LevelPeoples[CurrentLevel].SetActive(false);
        CurrentLevel++;
        Player.CitizensRequired = LevelAmounts[CurrentLevel];
        Player.UpdateObjective();
        Player.ResetPosition();
        LevelPeoples[CurrentLevel].SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
