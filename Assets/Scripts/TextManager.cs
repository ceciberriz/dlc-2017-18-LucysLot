using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {

    private Conversation conversation = new Conversation();
    private Text playerText;
    private Text pollyText;

    private int timer = 0;
    private bool done = false;
    private Stack<int> currentIndex = new Stack<int>();
    private Stack<NPCMessage[]> currentNPCSequence = new Stack<NPCMessage[]>();
    private Stack<PlayerMessage[]> currentPlayerOptions = new Stack<PlayerMessage[]>();

    private bool isPlayer = false;

    private bool clicked = false;
    private bool buttonClicked = false;

    public Button dialogueButton;

    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
    }

    private void Start()
    {
        //Button btn = dialogueButton.GetComponent<Button>(); 
        Button btn = GameObject.Find("/Canvas/Button").GetComponent<Button>();
        btn.onClick.AddListener(SetButtonClicked);
    }


    private void Update()
    {
        if (clicked)
        {
            if (!done)
            {
                GameObject polly = GameObject.Find("/Canvas/Panel/Text");
                GameObject player = GameObject.Find("/Canvas/Button/Text");
               

                pollyText = polly.GetComponent<Text>();
                playerText = player.GetComponent<Text>();

                currentIndex.Push(0);

                pollyText.text = conversation.getMessages()[currentIndex.Peek()].getText();

                currentNPCSequence.Push(conversation.getMessages());
                done = true;
            }
            if (isPlayer)
            {
                if (currentIndex.Peek() < currentPlayerOptions.Peek().Length) // this should select default player option
                {
                    // if we've received player input, break out of this loop and do some other stuff
                    if (buttonClicked)
                    {
                        Debug.Log("button clicked!");
                        if (currentPlayerOptions.Peek()[currentIndex.Peek()].hasResponse())
                        {
                            currentIndex.Push(0);
                            currentNPCSequence.Push(currentPlayerOptions.Peek()[currentIndex.Peek()].getResponse());
                            pollyText.text = currentNPCSequence.Peek()[currentIndex.Peek()].getText();
                            isPlayer = false;
                        }
                        buttonClicked = false;
                    }

                    if (timer / 300 > currentIndex.Peek())
                    {
                        Debug.Log("here");
                        PlayerMessage currentPlayerMessage = currentPlayerOptions.Peek()[currentIndex.Peek()];
                        playerText.text = currentPlayerMessage.getText();
                        currentIndex.Push(currentIndex.Pop() + 1);
                    }
                    timer++;
                }
                else
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
                } else
                {
                    currentNPCSequence.Pop();
                }
            }
        }
    }

    public void setClicked()
    {
        clicked = true;
    }

    public void SetButtonClicked()
    {
        buttonClicked = true;
    }
}

// public Text npcText;
// public Text playerText;
//dialogue = npc.GetComponent<NPCText>();
// npcText.text = dialogue.say();