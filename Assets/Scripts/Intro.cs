using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public GameObject FadePannel;
    public GameObject[] intro_images = new GameObject[3];
    public bool isIntroEnd = false;
    public GameObject ItemSpawner;
    public GameObject BirdSpawner;
    public GameObject ObstacleSpawner;
    public GameObject GooseSpawner;
    float fadeCount = 0;

    private void Start()
    {
        
        StartCoroutine(FadeCoroutine());

    }
    
    IEnumerator FadeCoroutine()
    {

        for (int i = 0; i < intro_images.Length; i++)
        {
            GameObject image = intro_images[i];
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

        FadePannel.SetActive(false);
        for (int i = 0; i < intro_images.Length; i++)
        {
            GameObject image = intro_images[i];
            image.SetActive(false);
        }
        isIntroEnd = true;
        //Destroy(FadePannel);
        ItemSpawner.SetActive(true);
        BirdSpawner.SetActive(true);
        ObstacleSpawner.SetActive(true);
        GooseSpawner.SetActive(true);
    }
}
