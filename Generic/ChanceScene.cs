using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChanceScene : MonoBehaviour
{
    [SerializeField] private LevelConnection connection;
    [SerializeField] private string nextScene;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] Transform player;

    private void Start()
    {
        if (connection == LevelConnection.activeConnection)
        {
            player.position = spawnPoint.position;
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelConnection.activeConnection = connection;
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        }
    }
}
