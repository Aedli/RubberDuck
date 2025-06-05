using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    public float GoalTime = 30.0f;
    public bool isGoal = false;
    public GameObject timerText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        GoalTime -= Time.deltaTime;
        if (isGoal == false && GoalTime < 0)
        {
            Debug.Log("실패");
            Time.timeScale = 0f;
        }
        if (isGoal)
        {
            Debug.Log("목표 도달");
            Time.timeScale = 0f;
        }

        timerText.GetComponent<TextMeshProUGUI>().text = "TIME : " + GoalTime.ToString("F1");
    }
}
