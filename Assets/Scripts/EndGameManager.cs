using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour {

    public Button finishButton;
    public GameObject completePanel;
    public GameObject gm;

	public void ShowFinishButton()
    {
        finishButton.gameObject.SetActive(true);
    }

    public void CompleteChallenge()
    {
        gm.GetComponent<OverallGameManager>().ToggleModeStatus();
        finishButton.gameObject.SetActive(false);
        completePanel.SetActive(true);
    }
}
