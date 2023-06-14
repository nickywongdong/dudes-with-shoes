using System;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    public Animator playerAnimator;

    enum CombatType
    {
        Attack,
        Block
    }
    enum Attack
    {
        SwingRight,
        SwingLeft,
        SwingDown,
        Stab
    }

    enum Block
    {
        BlockRight,
        BlockLeft,
        BlockLower,
        BlockUpper
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DirectionCheck(CombatType.Attack);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            DirectionCheck(CombatType.Block);
        }
    }

    void DirectionCheck(CombatType CombatType)
    {
        if (Input.GetAxis("Mouse X") < 0 && Input.GetAxis("Mouse Y") < 0.15f && Input.GetAxis("Mouse Y") > -0.15f)
        {
            PerformAction(CombatType, nameof(Attack.SwingRight), nameof(Block.BlockLeft));
        }
        else if (Input.GetAxis("Mouse X") > 0 && Input.GetAxis("Mouse Y") < 0.15f && Input.GetAxis("Mouse Y") > -0.15f)
        {
            PerformAction(CombatType, nameof(Attack.SwingLeft), nameof(Block.BlockRight));
        }
        else if (Input.GetAxis("Mouse Y") > 0 && Input.GetAxis("Mouse X") < 0.15f && Input.GetAxis("Mouse X") > -0.15f)
        {
            PerformAction(CombatType, nameof(Attack.SwingDown), nameof(Block.BlockUpper));
        }
        else if (Input.GetAxis("Mouse Y") < 0 && Input.GetAxis("Mouse X") < 0.15f && Input.GetAxis("Mouse X") > -0.15f)
        {
            PerformAction(CombatType, nameof(Attack.Stab), nameof(Block.BlockLower));
        }
    }

    void PerformAction(CombatType CombatType, string AttackMove, string BlockMove)
    {
        if (CombatType == CombatType.Attack)
        {
            //Debug.Log($"Performing Attack Move: {AttackMove}");
            playerAnimator.SetTrigger(AttackMove);
        }
        else if (CombatType == CombatType.Block)
        {
            //Debug.Log($"Performing Block Move: {BlockMove}");
            playerAnimator.SetTrigger(BlockMove);
        }
        else
        {
            Debug.LogError($"Unsupported Combat Type: ${CombatType}");
        }
    }
}
