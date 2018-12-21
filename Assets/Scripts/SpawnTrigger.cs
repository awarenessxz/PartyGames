using UnityEngine;

public class SpawnTrigger : MonoBehaviour {

    public MM1_BalloonPopper modeManager;

    // Use this for initialization
    void Start()
    {
        modeManager = modeManager.GetComponent<MM1_BalloonPopper>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BalloonRow")
        {
            modeManager.TriggerSpawn();
        }
    }
}
