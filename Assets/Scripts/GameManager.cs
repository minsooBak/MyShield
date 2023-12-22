using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public GameObject square;
    public Text timeTxt;
    public Text tishTxt;
    public Text MaxTxt;
    public GameObject endPanel;
    public Animator anim;
    float time = 0f;
    bool isRun = true;
    private void Awake()
    {
        I = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        InvokeRepeating("makeSquare", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRun)
        {
            time += Time.deltaTime;
            timeTxt.text = time.ToString("N2");
        }
    }

    void makeSquare()
    {
        Instantiate(square);
    }

    public void GameOver()
    {
        if(PlayerPrefs.HasKey("MaxScore") == false)
        {
            PlayerPrefs.SetFloat("MaxScore", time);
        }else
        {
            if(time>PlayerPrefs.GetFloat("MaxScore"))
            {
                PlayerPrefs.SetFloat("MaxScore", time);
            }
        }
        Invoke("timeStop", 0.5f);
        endPanel.SetActive(true);
        anim.SetBool("isDie", true);
        float maxScore = PlayerPrefs.GetFloat("MaxScore");
        MaxTxt.text = maxScore.ToString("N2");
        tishTxt.text = timeTxt.text;
        isRun = false;
    }
    void timeStop()
    {
        Time.timeScale = 0;
    }
    public void retry()
    {
        SceneManager.LoadScene("MainScene");
    }
}
