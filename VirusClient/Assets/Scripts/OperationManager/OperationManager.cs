using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperationManager : Manager
{
    private OperationManager opManager = null;
    public OperationManager operationManager
    {
        get
        {
            return opManager;
        }
        set
        {
            opManager = value;
            opManager.Init();
        }
    }

    public override void Init()
    {
        base.Init();
        operationManager = new DestopOperationManager();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Destory()
    {
        base.Destory();
    }
}
