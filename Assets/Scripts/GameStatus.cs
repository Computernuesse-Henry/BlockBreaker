using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameStatus : MonoBehaviour
{
   [Range(0.1f , 30f) ]  [SerializeField] float speed;
    [SerializeField] int PointsPerBlock = 10;
    [SerializeField] int Score = 0;
    [SerializeField] TextMeshProUGUI scoreField;
    

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy (gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);

        }
    }
    void Start()

    {
        scoreField.text = Score.ToString();
    }

    
    void Update()
    {
        Time.timeScale = speed;

    } 

    public void Scorecalculador()
    {
        Score = PointsPerBlock + Score;
        scoreField.text = Score.ToString();

    }
}
