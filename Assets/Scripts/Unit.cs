using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Unit : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        Debug.Log("Unit Spawned!");
    }
}
