using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField] private GameObject unitPrefab;
    [SerializeField] private int squadSize;

    [ServerRpc]
    public void SpawnUnitServerRpc(Vector3 pos, Quaternion quaternion)
    {
        GameObject go = Instantiate(unitPrefab, pos, quaternion);
        if(OwnerClientId == 1) {
            go.transform.Translate(new Vector3(0, 0, 5));
            go.GetComponentInChildren<Renderer>().material.color = Color.blue;
        }
        else
        {
            go.transform.Translate(new Vector3(0, 0, -5));
            go.GetComponentInChildren<Renderer>().material.color = Color.red;
        }
        go.GetComponent<NetworkObject>().SpawnWithOwnership(OwnerClientId);
    }

    private void OnEnable()
    {
        if (!IsClient) return;

    }

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) return; // Only the local client runs the code below this line.

        for (int i = 0; i < squadSize; i++)
        {
            SpawnUnitServerRpc(new Vector3(i * 4, 0), Quaternion.identity);
        }

    }
}