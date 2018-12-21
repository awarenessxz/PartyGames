using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {


    public MM1_BalloonPopper modeManager;
    public Button[] controls;
    public GameObject wrongMove;

    public void OnPinkButtonClicked()
    {
        modeManager.TryPopBalloonAtPos(3);
    }

    public void OnGreenButtonClicked()
    {
        modeManager.TryPopBalloonAtPos(2);
    }

    public void OnBlueButtonClicked()
    {
        modeManager.TryPopBalloonAtPos(1);
    }

    public void HaltInput()
    {
        wrongMove.SetActive(true);
        foreach(Button but in controls)
        {
            but.enabled = false;
        }
        Invoke("EnableInput", 0.5f);
    }

    private void EnableInput()
    {
        wrongMove.SetActive(false);
        foreach (Button but in controls)
        {
            but.enabled = true;
        }
    }
}
