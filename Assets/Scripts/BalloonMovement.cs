using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BalloonMovement : MonoBehaviour {

    public float speed = 8f;

    // Update is called once per frame
    void Update () {
        transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        speed = 8f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "TriggerPoint")
        {
            speed = 0;
        }
    }
}
