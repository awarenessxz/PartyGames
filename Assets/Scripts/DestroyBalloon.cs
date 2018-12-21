using UnityEngine;

public class DestroyBalloon : MonoBehaviour {

    public GameObject popBalloonPrefab;

    public void PopBalloon()
    {
        Destroy(gameObject);
        if (popBalloonPrefab != null)
        {
            GameObject popping = (GameObject)Instantiate(popBalloonPrefab);
            popping.transform.position = transform.position;
        }
    }
}
