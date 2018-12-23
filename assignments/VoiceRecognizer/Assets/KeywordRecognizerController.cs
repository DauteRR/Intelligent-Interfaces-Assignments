using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class KeywordRecognizerController : MonoBehaviour, IRecognizerController {

    KeywordRecognizer recognizer;
	string[] keywords = {"Queso", "Gofio", "Ropa vieja", "Escaldón", "Queso asado"};

	public void Init() {
        recognizer = new KeywordRecognizer (keywords);
		recognizer.OnPhraseRecognized += OnPhraseRecognition;
	}

	public void StartRecognition() {
        if (PhraseRecognitionSystem.Status == SpeechSystemStatus.Running)
            PhraseRecognitionSystem.Shutdown();
        if (recognizer != null && !recognizer.IsRunning)
		    recognizer.Start ();
	}

	public void PauseRecognition() {
        if (recognizer != null && recognizer.IsRunning)
            recognizer.Stop ();
	}

	public void FinishRecognition() {
        if (recognizer != null) {
            recognizer.Dispose();
            if (recognizer.IsRunning)
                PhraseRecognitionSystem.Shutdown();
        }
	}

    void OnPhraseRecognition(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text + " (" + args.confidence + ")");
    }
}
