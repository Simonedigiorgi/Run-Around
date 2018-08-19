using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject world;
    public float worldSpeed;

    [HideInInspector] public float timeLeft;

    public Text timer;

    void Start()
    {

    }

    void Update () {

        // World rotation
        world.transform.Rotate(0, 0, worldSpeed * Time.deltaTime);

        timeLeft += Time.deltaTime;

        if (timeLeft < 0)
        {

        }

        // Show time text
        timer.text = "" + (int)timeLeft;

    }
}
