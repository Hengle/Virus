using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestopOperationManager : OperationManager
{

    private Vector3 mouseStartPos = Vector3.zero;
    private Vector3 mouseEndPos = Vector3.zero;
    private float moveSpeed = 1;//移动速度
    private float zoomSpeed = 0.1f;//缩放速度

    private bool isMouseMove = false;

    public override void Init()
    {

    }

    public void OnMouseMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMouseMove = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMouseMove = false;
            mouseStartPos = Vector3.zero;
            mouseEndPos = Vector3.zero;
        }
        if (isMouseMove)
        {
            if ((mouseEndPos == Vector3.zero) && (mouseStartPos == Vector3.zero))
            {
                mouseStartPos = Input.mousePosition;
                mouseEndPos = Input.mousePosition;
            }
            else
            {
                mouseStartPos = mouseEndPos;
                mouseEndPos = Input.mousePosition;
                GameKernel.Instance.battlePanelManager.OnBattleMapMove((mouseEndPos - mouseStartPos) * moveSpeed);
            }
        }
    }

    public void OnScrollMove()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                GameKernel.Instance.battlePanelManager.OnBattleMapScale(1+zoomSpeed);
            }
            else
            {
                GameKernel.Instance.battlePanelManager.OnBattleMapScale(1-zoomSpeed);
            }
        }
    }

    public override void Update()
    {
        base.Update();
        if (GameKernel.Instance.battlePanelManager.GetPanelActive())
        {
            OnMouseMove();
            OnScrollMove();
        }
    }

    public override void Destory()
    {
        base.Destory();
    }
}
