using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public List<GameObject> characters;
    [SerializeField] NetworkedClient client;
    const float CharacterSpeed = 10;

    void Start()
    {
        NetworkedClientProcessing.SetGameLogic(this);
    }
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            client.SendMessageToServer("A,");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            client.SendMessageToServer("D,");
        }
        if (Input.GetKey(KeyCode.W))
        {
            client.SendMessageToServer("W,");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            client.SendMessageToServer("S,");
        }
    }

    public void CreateCharacter(string name)
    {

        Sprite circleTexture = Resources.Load<Sprite>("Circle");

        GameObject character = new GameObject(name);

        character.AddComponent<SpriteRenderer>();
        character.GetComponent<SpriteRenderer>().sprite = circleTexture;
    }
}

