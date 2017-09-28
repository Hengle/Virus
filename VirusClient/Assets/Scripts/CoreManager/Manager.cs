using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager{
    public Manager()
    {
        GameKernel.Instance.onInitEvent += this.Init;
        GameKernel.Instance.onUpdateEvent += this.Update;
        GameKernel.Instance.onDestoryEvent += this.Destory;
    }

    public virtual void Init()
    {
        
    }

    public virtual void Update()
    {

    }

    public virtual void Destory()
    {

    }
}
