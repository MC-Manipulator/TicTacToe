using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public StateController Controller;
    public BoardInfo BoardInfo;
    public bool isPaused;

    [Header("Prefab")]
    public GameObject BlankPrefab;

    [Header("GameObject Referrence")]
    public List<GameObject> BlankObjectList;

    [Header("UI Referrence")]
    public GameObject PausePanel;
    public GameObject EndPanel;
    public TMP_Text EndPanelTitle;
    public TMP_Text TurnStatementText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Controller = new StateController(this);
        isPaused = false;
    }

    void Start()
    {
        Controller.ChangeState(new GameStartState(), false);
        AudioManager.Instance.PlayBGM("game");
    }

    public void GenerateNewBoard()
    {
        if (BlankObjectList != null && BlankObjectList.Count != 0)
        {
            for (int i = 0; i < BlankObjectList.Count; i++)
            {
                GameObject go = BlankObjectList[i];
                Destroy(go);
            }
        }
        BlankObjectList = new List<GameObject>();

        for (int i = 0;i < GameInfoManager.Instance.CurrentGameInfo.BoardSize;i++)
        {
            for (int j = 0;j < GameInfoManager.Instance.CurrentGameInfo.BoardSize;j++)
            {
                GameObject newBlank = Instantiate(BlankPrefab); 
                BlankObjectList.Add(newBlank);
                newBlank.transform.parent = GameObject.Find("Board").transform;
                newBlank.transform.position = new Vector2(
                    -GameInfoManager.Instance.CurrentGameInfo.BoardSize / 2f + j * 2 - 0.5f,
                    -GameInfoManager.Instance.CurrentGameInfo.BoardSize / 2f + i * 2 - 0.5f);
                newBlank.GetComponent<Blank>().Row = i;
                newBlank.GetComponent<Blank>().Col = j;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller != null && Controller.CurrentGameState != null)
        {
            Controller.CurrentGameState.StateUpdate();
        }
    }

    public void PlayerPlaceChess(int row, int col)
    {
        int playerNumber = ((PlayerTurnState)(Controller.CurrentGameState)).playerNumber;
        BoardInfo.PlaceChess(playerNumber, row, col);
        Controller.ChangeState(new WinningJudgeState(playerNumber), false);
    }

    public void ComputerPlaceChess(int row, int col)
    {
        BoardInfo.PlaceChess(2, row, col);
        foreach (GameObject gb in BlankObjectList)
        {
            Blank blank = gb.GetComponent<Blank>();
            if (blank.Col == col && blank.Row == row)
            {
                blank.ComputerPlaceChess();
                break;
            }
        }
        GameManager.Instance.Controller.ChangeState(new WinningJudgeState(2), true);
    }

    public void Pause()
    {
        AudioManager.Instance.PlaySFX("confirm");
        PausePanel.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        AudioManager.Instance.PlaySFX("confirm");
        PausePanel.SetActive(false);
        isPaused = false;
    }

    public void OpenEndPanel(string endTitle)
    {
        EndPanelTitle.text = endTitle;
        EndPanel.SetActive(true);
    }

    public void CloseEndPanel()
    {
        EndPanel.SetActive(false);
    }

    public void RestartGame()
    {
        AudioManager.Instance.PlaySFX("confirm");
        Controller.ChangeState(new GameStartState(), false);
        CloseEndPanel();
    }

    public void ReturnToMenu()
    {
        AudioManager.Instance.PlaySFX("confirm");
        SceneManager.LoadScene("MainMenu");
    }

    public void GameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
