using UnityEngine;
using UnityEngine.UI;

public class ControllerUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletsUI;

    [SerializeField]
    private Text _bulletsText;

    [SerializeField]
    private GameObject _gameOverUI;

    [SerializeField]
    private GameObject _youWinUI;

    public Text BulletsText
    {
        get {return _bulletsText;}
    }

    public void ShowBulletsUI(bool show)
    {
        _bulletsUI.SetActive(show);
    }

    public void ShowGameOverUI(bool show)
    {
        _gameOverUI.SetActive(show);
    }

    public void ShowWinScreenUI(bool show)
    {
        _youWinUI.SetActive(show);
    }
}
