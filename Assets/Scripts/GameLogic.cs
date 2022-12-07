using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject character;
    [SerializeField] NetworkedClient client;
    const float CharacterSpeed = 10;

    void Start()
    {
        NetworkedClientProcessing.SetGameLogic(this);

        Sprite circleTexture = Resources.Load<Sprite>("Circle");

        character = new GameObject("Character");

        character.AddComponent<SpriteRenderer>();
        character.GetComponent<SpriteRenderer>().sprite = circleTexture;
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            client.SendMessageToServer("A," + ParsePosition());
        }
        else if (Input.GetKey(KeyCode.D))
        {
            client.SendMessageToServer("D," + ParsePosition());
        }
        if (Input.GetKey(KeyCode.W))
        {
            client.SendMessageToServer("W," + ParsePosition());
        }
        else if (Input.GetKey(KeyCode.S))
        {
            client.SendMessageToServer("S," + ParsePosition());
        }
    }
    string ParsePosition()
    {
        return character.transform.position.x.ToString() + "," + character.transform.position.y.ToString();
    }
}

