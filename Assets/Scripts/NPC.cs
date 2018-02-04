using System.Collections;
using System.Collections.Generic;
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

    private TextManager textManager;

	// Use this for initialization
	void Start () {

        textManager = gameObject.AddComponent(typeof(TextManager)) as TextManager;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        textManager.setClicked();
    }
}