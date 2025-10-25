using UnityEngine;

public class xelevator : MonoBehaviour
{
    public float detectDistance = 2f;     // �̻������Z��
    public LayerMask wallLayer;            // ���w����ϼh0
    public float speed = 2f;            // ���x�W�ɳt��
    public float xway = 5f,height=5f,zway=5f;           // �W�ɰ���
    public KeyCode triggerKey = KeyCode.E; // Ĳ�o����

    private Vector3 startPos,latestpos;           // �_�l��m
    private bool movingUp = false;      // �O�_�b�W�ɤ�
    public float ontop = 0f; // ���a�O�_�b���x�W
    public Transform player;           // ���a Transform

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float CheckWallDistance(Vector3 direction)
        {
            RaycastHit hit;

            // �o�g�g�u�˴�
            if (Physics.Raycast(player.transform.position, direction, out hit, detectDistance, wallLayer))
            {
                return hit.distance; // �g�u���𪺶Z��
            }

            return -1f; // -1 ��ܨS������
        }
        ontop = CheckWallDistance(-player.transform.up);//���a���U��O���O���
        // ���a�b���x�W�B���U����
        if (ontop != -1 && Input.GetKeyDown(triggerKey))
        {
            movingUp = true;
            // ���a�����l���� �� ���x���ʮɷ|�a�ۥL
           player.SetParent(transform);
        }

        // ���x����
        if (movingUp)
        {
            Vector3 targetPos = startPos + new Vector3(xway, height, zway);
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            
            player.position = player.position + (transform.position - latestpos);
            latestpos = transform.position;

        }

        if (transform.position == startPos + new Vector3(xway, height, zway) || ontop == -1)
        {
            movingUp = false;
            // ���x��F�ؼЦ�m��A�Ѱ����a���l�������Y
            /*if (player != null)
            {
                player.SetParent(null);
            }*/
        }

        if (ontop == -1 && transform.position != startPos)//���a���}���x
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
        }
    }
}
