using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public float GoalTime = 60.0f;
    public bool isGoal = false;
    public GameObject timerText;
    public GameObject GameOverImg;
    public GameObject EndingImg;
    public PlayerController playerController;
    public Intro intro;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.hp <= 0)
        {
            Debug.Log("실패");
            Time.timeScale = 0f;
            SoundManager.Instance.bgmSource.Stop();
            GameOverImg.SetActive(true);
        }
        
        if (isGoal == false && GoalTime < 0)
        {
            Debug.Log("실패");
            Time.timeScale = 0f;
            SoundManager.Instance.bgmSource.Stop();
            GameOverImg.SetActive(true);
        }
        if (isGoal)
        {
            Debug.Log("목표 도달");
            Time.timeScale = 0f;
            EndingImg.SetActive(true);
        }
        if(intro.isIntroEnd == true)
        {
            GoalTime -= Time.deltaTime;
        }
     
        timerText.GetComponent<TextMeshProUGUI>().text = "TIME : " + GoalTime.ToString("F1");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundManager.Instance.bgmSource.Stop(); // BGM 끔
            isGoal = true;
        }
    }
}
