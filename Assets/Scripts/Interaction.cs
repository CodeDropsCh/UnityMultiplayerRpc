using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Interaction : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("key pressed");
            ActionServerRpc();
        }
    }

    [ClientRpc]
    void ActionClientRpc()
    {
        Debug.Log("client");
        var mats = Resources.LoadAll<Material>("Materials");

        if (IsHost)
        {
            GetComponent<MeshRenderer>().material = mats[1];
        }
        else
        {
            GetComponent<MeshRenderer>().material = mats[2];
        }

    }

    [ServerRpc(RequireOwnership = false)]
    void ActionServerRpc()
    {
        Debug.Log("server");
        ActionClientRpc();
    }

}
