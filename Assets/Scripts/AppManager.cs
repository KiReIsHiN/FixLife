using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour
{
    public Text panel1, panel2, panel3, panel4;

    public Button ok, fix, repeat, exit, information;

    public GameObject settingsPanel;

    public Slider fixSlider;

    public AudioSource sound1,sound2,sound3,sound4,sound5;

    public float fillSpeed;
    private float _targetProgress = 0;

    public void Start()
    {
        fixSlider = fixSlider.GetComponent<Slider>();
        fixSlider.value = 0f;
        OnButtonClick();
    }

    public void OnButtonClick()
    {
        ok.onClick.AddListener(MoveToStep2);
        fix.onClick.AddListener(MoveToStep3);
        repeat.onClick.AddListener(Repeat);
        exit.onClick.AddListener(QuitApp);
        information.onClick.AddListener(SetInformPanel);
    }

    public void FixedUpdate()
    {
        if (fixSlider.gameObject.activeSelf == false)
        {
            IncrementProgress(0f);
        }
        else { IncrementProgress(1f); }


        if (fixSlider.value < _targetProgress)
        {
            fixSlider.value += fillSpeed * Time.deltaTime;
        }

        if (fixSlider.value == 1f)
        {
            MoveToStep4();
            fixSlider.value = 0f;
            fixSlider.gameObject.SetActive(false);
        }

        sound1.volume = PlayerPrefs.GetFloat("SoundVolume");
        sound2.volume = PlayerPrefs.GetFloat("SoundVolume");
        sound3.volume = PlayerPrefs.GetFloat("SoundVolume");
        sound4.volume = PlayerPrefs.GetFloat("SoundVolume");
        sound5.volume = PlayerPrefs.GetFloat("SoundVolume");
    }
    public void IncrementProgress(float newProgress)
    {
        _targetProgress = fixSlider.value + newProgress;
    }





    void MoveToStep2()
    {
        panel1.gameObject.SetActive(false);
        panel2.gameObject.SetActive(true);
        ok.gameObject.SetActive(false);
        fix.gameObject.SetActive(true);
    }

    void MoveToStep3()
    {
        panel2.gameObject.SetActive(false);
        panel3.gameObject.SetActive(true);
        fix.gameObject.SetActive(false);
        fixSlider.gameObject.SetActive(true);
    }
    public void MoveToStep4()
    {
        fixSlider.gameObject.SetActive(false);
        panel3.gameObject.SetActive(false);
        repeat.gameObject.SetActive(true);
        panel4.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
    }

    void Repeat()
    {
        repeat.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
        panel4.gameObject.SetActive(false);
        panel2.gameObject.SetActive(true);
        fix.gameObject.SetActive(true);
    }

    void QuitApp()
    {
        Application.Quit();
        Debug.Log("EXIT FROM APP");
    }

    void SetInformPanel()
    {
        if (settingsPanel.activeSelf == false)
            settingsPanel.SetActive(true);
        else if (settingsPanel.activeSelf == true)
            settingsPanel.SetActive(false);
    }


}
