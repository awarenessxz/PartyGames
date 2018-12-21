using UnityEngine;
using System.Collections;

public class MM1_BalloonPopper : MonoBehaviour {

    public GameObject[] balloons;
    public GameObject spawnPoint;
    public GameObject balloonRow;
    public GameObject spawnTrigger;
    public EndGameManager egm;
    public PlayerControl player;
    public float balloonSpacing = 1.9f;
    
    private int balloonCount;
    
    private Queue waitingLine;

	// Use this for initialization
	void Start () {
        balloonCount = 0;
        spawnTrigger.gameObject.SetActive(true);
        egm = egm.GetComponent<EndGameManager>();
        player = player.GetComponent<PlayerControl>();
        waitingLine = new Queue();
        TriggerSpawn();
    }

	// Update is called once per frame
	void Update () {
        if (balloonCount >= 20)
        {
            spawnTrigger.gameObject.SetActive(false);
        }

        if (waitingLine.Count <= 0)
        {
            egm.ShowFinishButton();
        }
	}

    private GameObject SpawnBalloon(int spawnPos)
    {
        Vector3 balloonPos = GetSpawnPos(spawnPos);
        int ballonIndex = Random.Range(0, balloons.Length);
        return Instantiate(balloons[ballonIndex], balloonPos, spawnPoint.gameObject.transform.rotation);
    }

    private Vector3 GetSpawnPos(int spawnChoice)
    {
        // identify x,y,z coordinates
        float posX = spawnPoint.gameObject.transform.position.x;

        if (spawnChoice == 0)   
        {
            posX -= balloonSpacing; // left
        }
        else if (spawnChoice == 2)
        {
            posX += balloonSpacing; //right
        }
        else
        {
            // center (no change)
        }

        Vector3 pos = new Vector3(posX, 0, 0);
        return pos;
    }

    public void TriggerSpawn()
    {
        // store the balloon positions
        Hashtable balloonPosInRow = new Hashtable();
        // determine how many balloons to show in the row
        int num = Random.Range(1, 3);
        balloonCount += num;
        // Create Row
        GameObject newBalloonRow = Instantiate(balloonRow, spawnPoint.gameObject.transform.position, spawnPoint.gameObject.transform.rotation);
        balloonPosInRow.Add(0, newBalloonRow);
        // spawn Balloon in row
        int spawnPos = Random.Range(0, 3); // [0, 3)
        GameObject balloon1 = SpawnBalloon(spawnPos);
        balloon1.transform.SetParent(newBalloonRow.transform, false);
        balloonPosInRow.Add(spawnPos + 1, balloon1);
        if (num > 1)
        {
            spawnPos = (spawnPos + 1) % 3;
            GameObject balloon2 = SpawnBalloon(spawnPos);
            balloon2.transform.SetParent(newBalloonRow.transform, false);
            balloonPosInRow.Add(spawnPos + 1, balloon2);
        }
        waitingLine.Enqueue(balloonPosInRow);
    }

    public void TryPopBalloonAtPos(int pos)
    {
        if (waitingLine.Count <= 0)
        {
            return;
        }

        Hashtable first = (Hashtable) waitingLine.Peek();
        
        if (first.ContainsKey(pos))
        {
            // animate balloon pop
            GameObject balloon = (GameObject)first[pos];
            balloon.GetComponent<DestroyBalloon>().PopBalloon();
            // remove from hashtable
            first.Remove(pos);
        } else
        {
            // Wrong Choice! 
            player.HaltInput();

        }

        if (first.Count <= 1)
        {
            GameObject balloonRow = (GameObject)first[0];
            Destroy(balloonRow);
            waitingLine.Dequeue();
        }
    }
}
