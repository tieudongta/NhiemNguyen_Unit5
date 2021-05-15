using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyController : MonoBehaviour
{
    private Button button;
    private GameManager gameMgr;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameMgr = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void SetDifficulty()
    {
        //Debug.Log(gameObject.name + " was clicked");
        gameMgr.StartGame(difficulty);

    }
}
