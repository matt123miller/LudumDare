/*
 * I've since learnt about the Observer pattern, maybe that would be better for controlling behaviour based on total number of enemies.
 * 
 */

using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private int spawnersON = 5;
    public int totalenemies;
    public GameObject gameoverscreen;
    public GameObject winscreen;
    public GameObject gameCamera;

    public int Points { get; private set; }

    private GameManager()
    {

    }

    private void Start()
    {
        _instance = this;
    }

    public void Reset()
    {
        Points = 0;
    }

    public void ResetPoints(int points)
    {
        Points = points;
    }

    public void AddPoints(int pointsToAdd)
    {
        Points += pointsToAdd;
        //maybe play tinkling points sound
    }

    public void GameOver()
    {
        gameCamera.transform.Rotate(180, 90, 90);
        gameoverscreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void Win()
    {
        gameCamera.transform.Rotate(180, 90, 90);
        winscreen.SetActive(true);
        Time.timeScale = 0; 
    }


    public void ReduceEnemyCount()
    {
        totalenemies--;
        if (totalenemies <= 0)
        {
            Win();   
        }
    }

}

