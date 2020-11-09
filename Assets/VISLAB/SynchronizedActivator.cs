using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class ObjectActivate{
    public bool serverOnly = false;

    public GameObject gameobjectToToggle;

    public KeyCode keycode;

    public bool startEnabled;

}

[RequireComponent(typeof(NetworkIdentity))]
public class SynchronizedActivator : NetworkBehaviour
{
    [SerializeField]
    private ObjectActivate[] toggableObjects;

    [SerializeField]

    private List<KeyCode> availableKeyCodes = new List<KeyCode>();

    private void Start(){
        foreach (var ob in toggableObjects)
        {
            ob.gameobjectToToggle.SetActive(ob.startEnabled);
            availableKeyCodes.Add(ob.keycode);
            
        }
    } 

    private void Update(){
        if (!isServer) return;
        for (int i = 0; i < toggableObjects.Length; i++)
        {
            var ob = toggableObjects[i];
            if (Input.GetKeyDown(ob.keycode)){
                var isActive = !ob.gameobjectToToggle.activeSelf;
                ob.gameobjectToToggle.SetActive(isActive);
                if (!ob.serverOnly){
                 RpcTest(i, isActive);
                }
            }
        }

    }

    [ClientRpc]
    private void RpcTest(int index, bool toggle){
        toggableObjects[index].gameobjectToToggle.SetActive(toggle);
    }
}
