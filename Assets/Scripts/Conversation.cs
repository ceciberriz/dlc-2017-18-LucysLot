using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Conversation{

    private NPCMessage[] messages;

    public Conversation()
    {
        messages = new NPCMessage[] {
            new NPCMessage("Hiooooooooooooooooooooooo!",
                  new PlayerMessage[] {new PlayerMessage("ayy", new NPCMessage[] {new NPCMessage("you selected ayy", null)}), new PlayerMessage("lmao", null)}),
            new NPCMessage("I'm Polly!", null),
            new NPCMessage("What's your name?", null) };
    }

    public NPCMessage[] getMessages()
    {
        return messages;
    }
}
