using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static bool RandomSpawning = false;

    //미션
    public int M1count = 0;
    public int M2count = 0;
    [SerializeField]
    private Text Mission1Tex;
    [SerializeField]
    private Text Mission2Tex;

    //물체 듦 여부
    public static bool IsHold = false;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }
    [SerializeField]
    private GameObject MissionPanel;

    // Start is called before the first frame update
    void Start()
    {
        Mission1Tex.text = "해초 5개 먹기   " + M1count + " / 5";
        Mission2Tex.text = "돌맹이 여과기에 10개 넣기   " + M2count + " / 10";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MissionPanel.SetActive(false);
        }
        if(M1count >= 5 && M2count >= 10)
        {
            SceneManager.LoadScene("Ending");
        }
    }

    public void MissionWin()
    {
        MissionPanel.SetActive(true);

        if (M1count >= 5)
            Mission1Tex.text = "해초 5개 먹기   " + M1count + " / 5  완료!";
        else
            Mission1Tex.text = "해초 5개 먹기   " + M1count + " / 5";
        if (M2count >= 10)
            Mission2Tex.text = "돌맹이 여과기에 10개 넣기   " + M2count + " / 10  완료!";
        else
            Mission2Tex.text = "돌맹이 여과기에 10개 넣기   " + M2count + " / 10";
    }
}
