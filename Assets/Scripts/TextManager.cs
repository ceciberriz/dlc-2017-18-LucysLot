using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    private Conversation conversation = new Conversation();
    private Text playerText;
    private Text pollyText;

    private int timer = 0;
    private Stack<int> currentIndex = new Stack<int>();
    private Stack<NPCMessage[]> currentNPCSequence = new Stack<NPCMessage[]>();
    private Stack<PlayerMessage[]> currentPlayerOptions = new Stack<PlayerMessage[]>();

    private bool isPlayer = false;
 
    private void Start()
    {
        GameObject polly = GameObject.Find("/Canvas/Panel/Text");
        GameObject player = GameObject.Find("/Canvas/Button/Text");

        pollyText = polly.GetComponent<Text>();
        playerText = player.GetComponent<Text>();

        currentIndex.Push(0);

        pollyText.text = conversation.getMessages()[currentIndex.Peek()].getText();

        currentNPCSequence.Push(conversation.getMessages());
    }
    
    private void Update()
    {
        if (isPlayer) {
            if (currentIndex.Peek() < currentPlayerOptions.Peek().Length) // this should select default player option
            {
                // if we've received player input, break out of this loop and do some other stuff
                if (false)
                {
                    if (currentPlayerOptions.Peek()[currentIndex.Peek()].hasResponse())
                    {
                        currentIndex.Push(0);
                        currentNPCSequence.Push(currentPlayerOptions.Peek()[currentIndex.Peek()].getResponse());
                        isPlayer = false;
                    }
                }

                if (timer / 300 > currentIndex.Peek())
                {
                    Debug.Log("here");
                    PlayerMessage currentPlayerMessage = currentPlayerOptions.Peek()[currentIndex.Peek()];
                    playerText.text = currentPlayerMessage.getText();
                    currentIndex.Push(currentIndex.Pop() + 1);
                }
                timer++;
            } else
            {
                currentPlayerOptions.Pop();
                currentIndex.Pop();
                isPlayer = false;
            }
            // default option
            //if (currentIndex.Peek() == currentPlayerOptions.Peek().Length) {//default option
            //}
        }
        else
        {
            if (currentIndex.Peek() < currentNPCSequence.Peek().Length)
            {
                if (timer / 300 > currentIndex.Peek())
                {
                    NPCMessage currentNPCMessage = currentNPCSequence.Peek()[currentIndex.Peek()];
                    pollyText.text = currentNPCMessage.getText();

                    currentIndex.Push(currentIndex.Pop() + 1);

                    if (currentNPCMessage.hasResponses())
                    {
                        currentIndex.Push(0);
                        currentPlayerOptions.Push(currentNPCMessage.getResponses());
                        isPlayer = true;
                    }
                }
                timer++;
            }
        }
    }

}

// public Text npcText;
// public Text playerText;
//dialogue = npc.GetComponent<NPCText>();
// npcText.text = dialogue.say();