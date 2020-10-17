﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CharacterFollower : MonoBehaviour
{
    public Transform target;
    public string partyMemberID;
    public float senseRange = 20f;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    public bool sprintDust = true;
    public Transform spriteGraphic;
    public Animator characterAnimator;
    public ParticleSystem dustParticleSystem;
    public GameObject configTarget;
    private SaveManager saveManager;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rigidbody2d;
    private CharacterMovement characterMovement;


    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        characterMovement = FindObjectOfType<CharacterMovement>();
        saveManager = configTarget.GetComponent<SaveManager>();

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }


    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rigidbody2d.position, target.position, OnPathComplete);
        }
    }


    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {


        // Emmit dust when going fast
        if (speed >= 2000 && sprintDust)
        {
            if (!dustParticleSystem.isPlaying)
            {
                    dustParticleSystem.Play();
            }
        }

        else
        {
            dustParticleSystem.Stop();
        }

        if (path == null)
        {
            return;
        }

        if (reachedEndOfPath)
        {
            // This is not currently in use but the if statment get rid of a warning in the log
        }

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        if (saveManager.activeSave.partyMemberOne == partyMemberID || saveManager.activeSave.partyMemberTwo == partyMemberID || saveManager.activeSave.partyMemberThree == partyMemberID)
        {
            speed = characterMovement.movementSpeed * 300;

            // Move toward target
            if (Vector2.Distance(rigidbody2d.position, target.position) <= senseRange)
            {
                Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rigidbody2d.position).normalized;
                Vector2 force = direction * speed * Time.deltaTime;
                rigidbody2d.AddForce(force);

                float distance = Vector2.Distance(rigidbody2d.position, path.vectorPath[currentWaypoint]);

                if (distance < nextWaypointDistance)
                {
                    currentWaypoint++;
                }

                // Character animator
                characterAnimator.SetFloat("MoveX", direction.x);
                characterAnimator.SetFloat("MoveY", direction.y);
                /*if (rigidbody2d.velocity.x >= 0.01f)
                {
                    spriteGraphic.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
                }
                else if (rigidbody2d.velocity.x <= -0.01f)
                {
                    spriteGraphic.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                }*/
            }

            // Teleport to target if stuck
            if (Vector2.Distance(rigidbody2d.position, target.position) >= senseRange)
            {
                rigidbody2d.transform.position = new Vector2(target.transform.position.x, target.transform.position.y);
            }
        }
    }
}
