using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject _playerGameObject;
    public void Setup(bool didIDoGood)
    {
        if (didIDoGood == true)
        {
            gameObject.GetComponent<GameOver>().GetComponentInChildren<TextMeshProUGUI>().text = "you did it.";
        }
        else if (didIDoGood == false)
        {
            gameObject.GetComponent<GameOver>().GetComponentInChildren<TextMeshProUGUI>().text = "you did not do it.";
        }
        _playerGameObject.GetComponentInChildren<Laser>().enabled = false;
        _playerGameObject.GetComponent<FirstPersonController>().enabled = false;
        _playerGameObject.GetComponentsInChildren<ParticleSystem>().ToList().ForEach(ps => ps.Stop());
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Game");
    }
}
