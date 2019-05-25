using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject gameButtonPrefab;

    public List<ButtonSetting> buttonSettings;

    public Transform gameFieldPanelTransform;

    List<GameObject> gameButtons;

    private bool levelLoaded = false;

    int bleepCount = 3;

    List<int> bleeps;
    List<int> playerBleeps;

    private float timer = 1f;
    int levelsCompleted = 0;

    System.Random rg;

    bool inputEnabled = false;
    bool gameOver = false;

    void Start()
    {
        gameButtons = new List<GameObject>();

        CreateGameButton(0, new Vector3(-64, 64));
        CreateGameButton(1, new Vector3(64, 64));
        CreateGameButton(2, new Vector3(-64, -64));
        CreateGameButton(3, new Vector3(64, -64));

        StartCoroutine(SimonSays());
    }

    void CreateGameButton(int index, Vector3 position)
    {
        GameObject gameButton = Instantiate(gameButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        gameButton.transform.SetParent(gameFieldPanelTransform);
        gameButton.transform.localPosition = position;

        gameButton.GetComponent<Image>().color = buttonSettings[index].normalColor;
        gameButton.GetComponent<Button>().onClick.AddListener(() =>
        {
            OnGameButtonClick(index);
        });

        gameButtons.Add(gameButton);
    }

    void PlayAudio(int index)
    {
        float length = 0.5f;
        float frequency = 0.001f * ((float)index + 1f);

        AnimationCurve volumeCurve = new AnimationCurve(new Keyframe(0f, 1f, 0f, -1f), new Keyframe(length, 0f, -1f, 0f));
        AnimationCurve frequencyCurve = new AnimationCurve(new Keyframe(0f, frequency, 0f, 0f), new Keyframe(length, frequency, 0f, 0f));

        LeanAudioOptions audioOptions = LeanAudio.options();
        audioOptions.setWaveSine();
        audioOptions.setFrequency(44100);

        AudioClip audioClip = LeanAudio.createAudio(volumeCurve, frequencyCurve, audioOptions);

        LeanAudio.play(audioClip, 0.5f);
    }

    void OnGameButtonClick(int index)
    {
        if(!inputEnabled)
        {
            return;
        }

        Bleep(index);

        playerBleeps.Add(index);

        if(bleeps[playerBleeps.Count - 1] != index)
        {
            GameOver();
            return;
        }

        if(bleeps.Count == playerBleeps.Count)
        {
            StartCoroutine(SimonSays());
        }
    }

    void GameOver()
    {
        gameOver = true;
        inputEnabled = false;
        if (levelsCompleted != 7)
        {
            SceneManager.LoadScene("Study");
            GlobalControl.Instance.penPickedUp = false;
        }  
    }

    IEnumerator SimonSays()
    {
        inputEnabled = false;

        rg = new System.Random("hakunamatata".GetHashCode());

        SetBleeps();

        for(int i = 0; i < bleeps.Count; i++)
        {
            Bleep(bleeps[i]);

            yield return new WaitForSeconds(0.7f);
        }

        inputEnabled = true;

        yield return null;
    }

    void SetBleeps()
    {

        bleeps = new List<int>();
        playerBleeps = new List<int>();

        for(int i = 0; i < bleepCount; i++)
        {
            bleeps.Add(rg.Next(0, gameButtons.Count));
        }

        levelsCompleted++;
        if (levelsCompleted == 7)
        {

            SceneManager.LoadScene("Study");
            GlobalControl.Instance._score++;
            GlobalControl.Instance.penPickedUp = true;
            GameOver();
        }
        bleepCount++;
    }

    void Bleep(int index)
    {
        LeanTween.value(gameButtons[index], buttonSettings[index].normalColor, buttonSettings[index].highlightColor,
            0.25f).setOnUpdate(
            (Color color) => { gameButtons[index].GetComponent<Image>().color = color; });

            LeanTween.value(gameButtons[index], buttonSettings[index].highlightColor, buttonSettings[index].normalColor, 0.25f)
            .setDelay(0.5f)
            .setOnUpdate((Color color) =>
            {
                gameButtons[index].GetComponent<Image>().color = color;
            });

        PlayAudio(index);
    }

}


