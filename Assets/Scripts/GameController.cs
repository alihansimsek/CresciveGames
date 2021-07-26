using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int point = 0;
    public GameObject gameEndingUI;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void increasePoint()
    {
        point++;
        Debug.Log("point: "+point);
    }

    public void gameOver()
    {
        scoreText.text = "points: " + point;
        gameEndingUI.SetActive(true);
    }
    public void restart()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    
}
