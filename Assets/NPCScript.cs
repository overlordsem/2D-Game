using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    bool player_detection = false;



    // Update is called once per frame
    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.E)) 
        {
            print("Hey, it's me Ninja. I'm totally not talking in the console because i tried adding a dialogue box for ages and failed miserably. Anyways, Nickeh30 kidnapped your girlfriend i heard. Boohoo! You will NEVER get her back! I bet you won't even be able to beat this first stage! I made this stage myself. If you beat it, i'll harm myself.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            player_detection = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        {
            player_detection = false;
        }
    }
}
