using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float PipeSpeed;
    public GameObject PlayCanvas;
    public GameObject GameOverCanvas;
    public PipeSpawner PipeSpawner;
    public GameState gameState;

    // Start is called before the first frame update
    private void Start()
    {
        gameState = GameState.Start;
        PipeSpawner.gameObject.SetActive(false);
        PlayCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space) && !Input.GetMouseButtonDown(0)) return;
        switch (gameState)
        {
            case GameState.Start:
                gameState = GameState.Play;
                PipeSpawner.gameObject.SetActive(true);
                PipeSpeed = 2.5f;
                break;
            case GameState.GameOver:
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case GameState.Play:
            default:
                break;
        }
    }

    public void PlayerDead()
    {
        gameState = GameState.GameOver;

        PlayCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);
        PipeSpawner.gameObject.SetActive(false);
        PipeSpeed = 0;
    }
}

public enum GameState
{
    Start,
    Play,
    GameOver
}