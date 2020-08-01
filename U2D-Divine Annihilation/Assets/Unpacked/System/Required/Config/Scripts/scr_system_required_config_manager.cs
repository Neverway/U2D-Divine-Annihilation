﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_system_required_config_manager : MonoBehaviour
{
    // Globals
    public bool menuActive;
    public bool canMove;

    // Referances
    private scr_system_hud_textbox_manager DialogueManager;
    private scr_system_menu_inventory_manager InventoryManager;


    // Start is called before the first frame update
    void Start()
    {
        menuActive = false;
        DialogueManager = FindObjectOfType<scr_system_hud_textbox_manager>();
        InventoryManager = FindObjectOfType<scr_system_menu_inventory_manager>();
    }


    // Update is called once per frame
    void Update()
    {
        // Set the global.menuActive state
        if(DialogueManager.dialogueBoxActive | InventoryManager.inventoryBoxActive)
        {
            menuActive = true;
        }
        else if(!DialogueManager.dialogueBoxActive && !InventoryManager.inventoryBoxActive)
        {
            menuActive = false;
        }
    }
}
