using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public float GoalTime = 60.0f;
    public bool isGoal = false;
    public GameObject timerText;
    public GameObject GameOverImg;
    public GameObject[] ending_Imgs = new GameObject[2];
    public GameObject FadePannel;

    public PlayerController playerController;
    public GameObject ItemSpawner;
    public GameObject BirdSpawner;
    public GameObject ObstacleSpawner;
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
            
            

        }
        if(intro.isIntroEnd == true && isGoal != true)
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
            StartCoroutine(EndingCoroutine());
            ItemSpawner.SetActive(false);
            BirdSpawner.SetActive(false);
            ObstacleSpawner.SetActive(false);
        }
    }

    public IEnumerator EndingCoroutine()
    {
        FadePannel.SetActive(true);

        for (int i = 0; i < ending_Imgs.Length; i++)
        {
            GameObject image = ending_Imgs[i];
            for (float f = 0f; f < 2; f += 0.01f)
            {
                Color c = image.GetComponent<Image>().color;
                c.a = f;
                image.GetComponent<Image>().color = c;
                yield return null;
            }
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(1);
    }
}
