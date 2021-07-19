using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressSceneInstantiator : MonoBehaviour
{
    [SerializeField] GameObject ProgressScenePrefab;
    void Start()
    {
        if(FindObjectOfType<ProgressSceneLoader>() == null)
        {
            Instantiate(ProgressScenePrefab);
        }
    }
}
