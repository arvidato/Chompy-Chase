using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceScore : MonoBehaviour
{
    public Transform player;              // assign Character here
    public TextMeshProUGUI distanceText;  // assign TextMeshProUGUI in Canvas
    private float startX;

    void Start()
    {
        if (player != null)
            startX = player.position.x;  // save starting point
    }

    void Update()
    {
        if (player == null) return;

        // Distance traveled since start
        float distance = player.position.x - startX;

        // Show rounded distance (no decimals)
        distanceText.text = Mathf.FloorToInt(distance).ToString();
    }
}
