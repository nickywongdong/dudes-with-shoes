using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("I AM AWAKE");
    }
    private void OnEnable()
    {
        Debug.Log("Subscribing to gameover");
        // Subscribe to the player's death event
        PlayerHealth.OnGameOver += (DidIDoGood) => ShowGameOverScreen(DidIDoGood);
    }

    private void OnDisable()
    {
        Debug.Log("unsubbing from gameover action");
        // Unsubscribe from the player's death event
        PlayerHealth.OnGameOver -= (DidIDoGood) => ShowGameOverScreen(DidIDoGood);
    }

    private void ShowGameOverScreen(bool DidIDoGood)
    {
        Debug.Log("Attempting to show game over screen");
        if (isActiveAndEnabled)
        {
            Debug.Log("Alive and well");
        }
        else if (!isActiveAndEnabled)
        {
            Debug.Log("Somehow i'm dead");
        }
        Debug.Log(gameObject.IsDestroyed());
        Debug.Log(gameObject.name);
        Debug.Log(gameObject.transform.Find("Background"));
        var BackgroundChild = gameObject.transform.Find("Background");
        var GameOverText = BackgroundChild.transform.Find("GameOverText");
        
        if (DidIDoGood == true)
        {
            GameOverText.GetComponentInChildren<TextMeshProUGUI>().text = "you did it.";
        }
        else if (DidIDoGood == false)
        {
            GameOverText.GetComponentInChildren<TextMeshProUGUI>().text = "you did not do it.";
        }

        FindObjectOfType<FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Activate the game over screen UI
        BackgroundChild.gameObject.SetActive(true);

        // Pause the game or perform any necessary actions
        Time.timeScale = 0f;
    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        //Debug.Log("attempting to reset player health");
        //GetComponent<PlayerHealth>().ResetHealth();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene("Game");
    }

    private void OnDestroy()
    {
        Debug.Log("i'm being killed");
    }

}
