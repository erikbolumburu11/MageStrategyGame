using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Unit : NetworkBehaviour {
    public float moveSpeed = 100f;
    public override void OnNetworkSpawn()
    {
        Debug.Log("Unit Spawned!");
    }

    private void Update() {
        if (!IsOwner) return;
        
        Vector3 moveDir = new Vector3(0, 0, 0);

        if(Input.GetKeyDown(KeyCode.W)) moveDir.z = +1f;
        if(Input.GetKeyDown(KeyCode.S)) moveDir.z = -1f;
        if(Input.GetKeyDown(KeyCode.A)) moveDir.x = -1f;
        if(Input.GetKeyDown(KeyCode.D)) moveDir.x = +1f;
        
        transform.position += moveDir * moveSpeed * Time.deltaTime;
    }
}
