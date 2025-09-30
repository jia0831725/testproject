using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;

/*public class Floorteleport : MonoBehaviour
{
   * public KeyCode key =KeyCode.A;
    public Transform teleportTarget;
    // Start is called before the first frame update

    void OnTriggerStay(Collider other)
    {
        Vector3 playerPos = teleportTarget.position;
        if (other.CompareTag("Player")) 
        {
            Debug.Log("4");
            if (Input.GetKeyDown(key))
            {
                Debug.Log("t");
                other.transform.position = new Vector3(playerPos.x, playerPos.y + 1, playerPos.z);
            }
        }
    }
}*/

public class Floorteleport : MonoBehaviour
{
    public KeyCode key = KeyCode.A;          // 要觸發傳送的按鍵
    public Transform teleportTarget;         // 目標傳送位置
    public Transform player;                 // 玩家角色的 Transform
    private bool isPlayerInRange = false;    // 用來檢查玩家是否進入觸發器

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        // 檢查玩家是否在範圍內，並且按下傳送按鍵
        if (isPlayerInRange && Input.GetKeyDown(key))
        {
            TeleportPlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // 當玩家進入觸發器範圍，開始檢測按鍵
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // 當玩家離開觸發器範圍，停止檢測按鍵
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void TeleportPlayer()
    {
        if (teleportTarget != null)
        {
            // 設置玩家的位置為 teleportTarget 的位置，並略微提升 y 軸
            Vector3 targetPosition = teleportTarget.position;
            targetPosition.y += 1;  // 如果需要可以調整高度
            player.transform.position = targetPosition;

            Debug.Log("Player Teleported to: " + targetPosition);
        }
        else
        {
            Debug.LogError("Teleport Target is not assigned!");
        }
    }
}

