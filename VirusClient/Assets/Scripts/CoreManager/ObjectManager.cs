using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : Manager {
    private Dictionary<string, GameObject> gameObjectDictionary;
    public override void Init()
    {
        base.Init();
        gameObjectDictionary = new Dictionary<string, GameObject>();
    }

    public GameObject FindGameObjectByPath(string path)
    {
        GameObject gameObject = null;
        gameObjectDictionary.TryGetValue(path, out gameObject);
        if (!gameObject)
        {
            if (GameObject.Find(path))
            {
                gameObject = GameObject.Find(path);
                gameObjectDictionary.Add(path, gameObject);
            }
        }
        return gameObject;
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
