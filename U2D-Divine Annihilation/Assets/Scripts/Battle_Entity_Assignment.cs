﻿//=========== Written by Arthur W. Sheldon AKA Lizband_UCC ====================
//
// Purpose: Sets up the player's party
// Applied to: BattleController object in a battle scene
//
//=============================================================================

using UnityEngine;

public class Battle_Entity_Assignment : MonoBehaviour
{
    public GameObject partyMember1;
    public GameObject partyMember2;
    public GameObject partyMember3;
    public SpriteRenderer partyMember1Sprite;
    public SpriteRenderer partyMember2Sprite;
    public SpriteRenderer partyMember3Sprite;
    public Sprite idleSideFox;
    public Sprite idleSideMiyu;
    public Sprite idleSideSam;
    public Sprite idleSideCasey;

    public GameObject configTarget;
    private SaveManager saveManager;

    void Start()
    {
        saveManager = configTarget.GetComponent<SaveManager>(); // Set a reference to the SaveManager script on the Config object in the scene

        // PARTY SLOT 1
        if (saveManager.activeSave.partyMemberOne != "NULL") partyMember1.SetActive(true);
        else partyMember1.SetActive(false);
        if (saveManager.activeSave.partyMemberOne == "Fox") partyMember1Sprite.sprite = idleSideFox;
        if (saveManager.activeSave.partyMemberOne == "Miyu") partyMember1Sprite.sprite = idleSideMiyu;
        if (saveManager.activeSave.partyMemberOne == "Sam") partyMember1Sprite.sprite = idleSideSam;
        if (saveManager.activeSave.partyMemberOne == "Casey") partyMember1Sprite.sprite = idleSideCasey;


        // PARTY SLOT 2
        if (saveManager.activeSave.partyMemberTwo != "NULL") partyMember2.SetActive(true);
        else partyMember2.SetActive(false);
        if (saveManager.activeSave.partyMemberTwo == "Fox") partyMember2Sprite.sprite = idleSideFox;
        if (saveManager.activeSave.partyMemberTwo == "Miyu") partyMember2Sprite.sprite = idleSideMiyu;
        if (saveManager.activeSave.partyMemberTwo == "Sam") partyMember2Sprite.sprite = idleSideSam;
        if (saveManager.activeSave.partyMemberTwo == "Casey") partyMember2Sprite.sprite = idleSideCasey;


        // PARTY SLOT 3
        if (saveManager.activeSave.partyMemberThree != "NULL") partyMember3.SetActive(true);
        else partyMember3.SetActive(false);
        if (saveManager.activeSave.partyMemberThree == "Fox") partyMember3Sprite.sprite = idleSideFox;
        if (saveManager.activeSave.partyMemberThree == "Miyu") partyMember3Sprite.sprite = idleSideMiyu;
        if (saveManager.activeSave.partyMemberThree == "Sam") partyMember3Sprite.sprite = idleSideSam;
        if (saveManager.activeSave.partyMemberThree == "Casey") partyMember3Sprite.sprite = idleSideCasey;
    }


    void Update()
    {
    }
}
