using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public static Animator playerAnimator;
    enum Attacks
    {
        SwingRight,
        SwingLeft,
        SwingDown,
        Stab
    }

    enum Blocks
    {
        BlockRight,
        BlockLeft,
        BlockLower,
        BlockUpper
    }

    readonly Dictionary<string, Dictionary<string, Action>> CombatActions = new()
    {
        { 
            "Attack", new Dictionary<string, Action>
            {
                { nameof(Attacks.SwingRight) , () => playerAnimator.SetTrigger(nameof(Attacks.SwingRight)) },
                { nameof(Attacks.SwingLeft),    () => playerAnimator.SetTrigger(nameof(Attacks.SwingLeft)) },
                { nameof(Attacks.SwingDown),    () => playerAnimator.SetTrigger(nameof(Attacks.SwingDown)) },
                { nameof(Attacks.Stab),         () => playerAnimator.SetTrigger(nameof(Attacks.Stab)) }
            }
        },
        {
            "Block", new Dictionary<string, Action>
            {
                { nameof(Blocks.BlockRight),    () => playerAnimator.SetTrigger(nameof(Blocks.BlockRight)) },
                { nameof(Blocks.BlockLeft),     () => playerAnimator.SetTrigger(nameof(Blocks.BlockLeft)) },
                { nameof(Blocks.BlockLower),    () => playerAnimator.SetTrigger(nameof(Blocks.BlockLower)) },
                { nameof(Blocks.BlockUpper),    () => playerAnimator.SetTrigger(nameof(Blocks.BlockUpper)) }
            }
        }
    };

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DirectionCheck("Attacking");
        }
        else if ( Input.GetMouseButtonDown(1))
        {
            DirectionCheck("Blocking");
        }
    }

    void DirectionCheck(string CombatMove)
    {
        if (Input.GetAxis("Mouse X") < 0 && Input.GetAxis("Mouse Y") < 0.15f && Input.GetAxis("Mouse Y") > -0.15f)
        {
            CombatActions[CombatMove][nameof(Attacks.SwingRight)].Invoke();
            Debug.Log("Swinging Right");
        }
        else if (Input.GetAxis("Mouse X") > 0 && Input.GetAxis("Mouse Y") < 0.15f && Input.GetAxis("Mouse Y") > -0.15f)
        {
            playerAnimator.SetTrigger(nameof(Attacks.SwingLeft));
            Debug.Log("Swinging Left");
        }
        else if (Input.GetAxis("Mouse Y") > 0 && Input.GetAxis("Mouse X") < 0.15f && Input.GetAxis("Mouse X") > -0.15f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerAnimator.SetTrigger(nameof(Attacks.SwingDown));
                Debug.Log("Swinging Down");
            }
            else if (Input.GetMouseButtonDown(1))
            {
                playerAnimator.SetTrigger(nameof(Blocks.BlockUpper));
                Debug.Log("Block Upper");
            }
        }
        else if (Input.GetAxis("Mouse Y") < 0 && Input.GetAxis("Mouse X") < 0.15f && Input.GetAxis("Mouse X") > -0.15f)
        {
            playerAnimator.SetTrigger(nameof(Attacks.Stab));
            Debug.Log("Stabbing");
        }
    }
}
