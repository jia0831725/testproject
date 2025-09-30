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
    public KeyCode key = KeyCode.A;          // �nĲ�o�ǰe������
    public Transform teleportTarget;         // �ؼжǰe��m
    public Transform player;                 // ���a���⪺ Transform
    private bool isPlayerInRange = false;    // �Ψ��ˬd���a�O�_�i�JĲ�o��

    private void Start()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        // �ˬd���a�O�_�b�d�򤺡A�åB���U�ǰe����
        if (isPlayerInRange && Input.GetKeyDown(key))
        {
            TeleportPlayer();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // ���a�i�JĲ�o���d��A�}�l�˴�����
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // ���a���}Ĳ�o���d��A�����˴�����
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    void TeleportPlayer()
    {
        if (teleportTarget != null)
        {
            // �]�m���a����m�� teleportTarget ����m�A�ò��L���� y �b
            Vector3 targetPosition = teleportTarget.position;
            targetPosition.y += 1;  // �p�G�ݭn�i�H�վ㰪��
            player.transform.position = targetPosition;

            Debug.Log("Player Teleported to: " + targetPosition);
        }
        else
        {
            Debug.LogError("Teleport Target is not assigned!");
        }
    }
}

