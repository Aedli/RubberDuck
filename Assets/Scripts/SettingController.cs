using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingController : MonoBehaviour
{
    public GameObject setting_UI;
    public bool setting_Enabled = false;

    public void LoadToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && setting_Enabled == false)
        {
            setting_UI.SetActive(true);
            setting_Enabled = true;
            Time.timeScale = 0f;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && setting_Enabled == true)
        {
            setting_UI.SetActive(false);
            setting_Enabled = false;
            Time.timeScale = 1.0f;
        }

    }
}
