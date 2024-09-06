using UnityEngine;

public class UIController : Singleton<UIController>
{
    public HealthPanel HealthPanel => healthPanel;
    [SerializeField] private HealthPanel healthPanel;

    [SerializeField] private CustomToggle soundsToggle;
    [SerializeField] private GameObject pausePanel, gameOverPanel;

    private void Start()
    {
        soundsToggle.IsOn = !AudioController.Instance.SoundsMuted();

        soundsToggle.onValueChanged.AddListener(OnSoundsToggleSwitched);
    }

    private void OnSoundsToggleSwitched(bool v)
    {
        AudioController.Instance.SetSoundsMuteValue(!v);
    }

    public void Restart()
    {
        GameController.Instance.Restart();
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        GameController.Instance.Pause();
    }

    public void Unpause()
    {
        pausePanel.SetActive(false);
        GameController.Instance.Unpause();
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}