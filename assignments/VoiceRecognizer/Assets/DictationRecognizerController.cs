using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;

public class DictationRecognizerController : MonoBehaviour , IRecognizerController {

	private DictationRecognizer recognizer;

	public void Init () {
        recognizer = new DictationRecognizer();
		recognizer.DictationResult += (text, confidence) =>
		{
			Debug.LogFormat("Dictation result: {0}", text);
		};
		recognizer.DictationHypothesis += (text) =>
		{
			Debug.LogFormat("Dictation hypothesis: {0}", text);
		};
		recognizer.DictationComplete += (completionCause) =>
		{
			if (completionCause != DictationCompletionCause.Complete)
				Debug.LogErrorFormat("Dictation completed unsuccessfully: {0}.", completionCause);
		};
		recognizer.DictationError += (error, hresult) =>
		{
			Debug.LogErrorFormat("Dictation error: {0}; HResult = {1}.", error, hresult);
		};
	}

	public void StartRecognition() {
        if (PhraseRecognitionSystem.Status == SpeechSystemStatus.Running)
            PhraseRecognitionSystem.Shutdown();
        if (recognizer != null && recognizer.Status == SpeechSystemStatus.Stopped)
            recognizer.Start ();
	}

	public void PauseRecognition() {
        if (recognizer != null && recognizer.Status == SpeechSystemStatus.Running)
            recognizer.Stop();
	}

	public void FinishRecognition() {
        if (recognizer != null) {
            recognizer.Dispose();
            if (recognizer.Status == SpeechSystemStatus.Running)
                PhraseRecognitionSystem.Shutdown();
        }
    }
}
