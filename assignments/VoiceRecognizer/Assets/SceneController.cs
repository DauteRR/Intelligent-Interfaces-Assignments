using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[SerializeField]
interface IRecognizerController
{
    void Init();

    void StartRecognition();

    void PauseRecognition();

    void FinishRecognition();
}


public class SceneController : MonoBehaviour {

    private bool isRecognitionEnabled = false;
    private Dropdown dropdown;
    private IRecognizerController activeRecognizer;
    private DictationRecognizerController dictationRecognizer;
    private KeywordRecognizerController keywordRecognizer;
    private List<string> options = new List<string> {
        "Keywords Recognition",
        "Dictation Recognition",
    };

    void Start() {
        dictationRecognizer = 
            GameObject.Find("DictationRecognizerController").GetComponent<DictationRecognizerController>();
        keywordRecognizer = 
            GameObject.Find("KeywordRecognizerController").GetComponent<KeywordRecognizerController>();
        activeRecognizer = keywordRecognizer;
        activeRecognizer.Init();

        dropdown = GameObject.Find("Dropdown").GetComponent<Dropdown>();
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }

    public void OnRecognizerChange(int optionIndex) {
        StopRecognition();
        activeRecognizer.FinishRecognition();
        Debug.Log("Changing recognition to " + options[optionIndex]);
        switch (optionIndex) {
            case 0:
                activeRecognizer = keywordRecognizer;
                break;
            case 1:
                activeRecognizer = dictationRecognizer;
                break;
            default:
                return;
        }
        activeRecognizer.Init();
    }

    public void Recognize() {
        if (isRecognitionEnabled) {
            return;
        }
        Debug.Log("Starting recognition");
        isRecognitionEnabled = true;
        activeRecognizer.StartRecognition();
    }

    public void StopRecognition() {
        if (!isRecognitionEnabled) {
            return;
        }
        Debug.Log("Stopping recognition");
        isRecognitionEnabled = false;
        activeRecognizer.PauseRecognition();
    }
}
