using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHiding : MonoBehaviour
{
    [SerializeField] Transform leftGroundCheck;
    [SerializeField] Transform rightGroundCheck;

    PlayerMovement playerMovement;
    public bool isCanTranBlock;

    public KeyCode tranBlockKey;

    AgentAnimation anim;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = transform.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.onGround)
        {
            SideCheck();
        }
        if(Input.GetKeyDown(tranBlockKey) && isCanTranBlock)
        {
            //anim.TransfBlock(); // 내일 애니메이션 연결해야함
        }
    }

    private void SideCheck()
    {
        RaycastHit2D leftRay = Physics2D.Raycast(leftGroundCheck.position, Vector2.left, 0.1f, LayerMask.NameToLayer("Ground"));
        RaycastHit2D rightRay = Physics2D.Raycast(rightGroundCheck.position, Vector2.right, 0.1f, LayerMask.NameToLayer("Ground"));

        isCanTranBlock = leftRay | rightRay;
    }
}
