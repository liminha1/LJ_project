using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_effect : MonoBehaviour
{
public player player;

    private void OnTriggerEnter(Collider other)
    {
        player.jumpCount = 0;
    }
}
