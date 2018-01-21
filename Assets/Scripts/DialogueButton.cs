using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour {

    private TextManager textManager;

    // Use this for initialization
    void Start()
    {
        textManager = gameObject.AddComponent(typeof(TextManager)) as TextManager;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnClick()
    {
        Debug.Log("mouse down!!!");
<<<<<<< HEAD
        //textManager.SetButtonClicked();
=======
        textManager.SetButtonClicked();
>>>>>>> 2e17f755a01133c2f9b79151a062d23de7737a41
    }
}

