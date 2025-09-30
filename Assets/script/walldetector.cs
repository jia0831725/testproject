using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    public float detectDistance = 2f;     // �̻������Z��
    public LayerMask wallLayer;            // ���w����ϼh
    public Transform cameraTransform;

    // �|�Ӥ�V���Z��
    public float frontDistance=1;
    public float backDistance;
    public float leftDistance;
    public float rightDistance;
    public int cycle;//�������v���O�_����

    int a = 0,b=0;
    //float c=0;
    void Start()
    {
        float CheckWallDistance(Vector3 direction)
        {
            RaycastHit hit;

            // �o�g�g�u�˴�
            if (Physics.Raycast(transform.position, direction, out hit, detectDistance, wallLayer))
            {
                return hit.distance; // �g�u���𪺶Z��
            }

            return -1f; // -1 ��ܨS������
        }
        // ���e��
        frontDistance = CheckWallDistance(transform.forward);

        // �����
        backDistance = CheckWallDistance(-transform.forward);

        // ����
        leftDistance = CheckWallDistance(-transform.right);

        // �k��
        rightDistance = CheckWallDistance(transform.right);

        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        float CheckWallDistance(Vector3 direction)
        {
            RaycastHit hit;

            // �o�g�g�u�˴�
            if (Physics.Raycast(transform.position, direction, out hit, detectDistance, wallLayer))
            {
                return hit.distance; // �g�u���𪺶Z��
            }

            return -1f; // -1 ��ܨS������
        };

        if (frontDistance <= 2f && frontDistance > 0)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            a = 0;
            b = 0;
        }
        else if (backDistance <= 2f && backDistance > 0)
        {
            //transform.rotation = Quaternion.Euler(0, 180, 0);
            /*// ��180�׫᥿�e��
            backDistance = CheckWallDistance(transform.forward);

            // ��180�ץ����
            frontDistance = CheckWallDistance(-transform.forward);

            // ��180�ץ���
            rightDistance = CheckWallDistance(-transform.right);

            // ��180�ץk��
            leftDistance = CheckWallDistance(transform.right);*/
            a = 2;
            b = 0;
        }
        else if (leftDistance <= 2f && leftDistance > 0)
        {
            //transform.rotation = Quaternion.Euler(0, 270, 0);
            /*// ��270�ץ��e��
            leftDistance = CheckWallDistance(transform.forward);

            // ��270�ץ����
            rightDistance = CheckWallDistance(-transform.forward);

            // ��270�ץ���
            backDistance = CheckWallDistance(-transform.right);

            // ��270�ץk��
            frontDistance = CheckWallDistance(transform.right);*/
            a = 3;
            b = 0;
        }
        else if (rightDistance <= 2f && rightDistance > 0)
        {
            //transform.rotation = Quaternion.Euler(0, 90, 0);
            /* // ��90�ץ��e��
             rightDistance = CheckWallDistance(transform.forward);

             // ��90�ץ����
             leftDistance = CheckWallDistance(-transform.forward);

             // ��90�ץ���
             frontDistance = CheckWallDistance(-transform.right);

             // ��90�ץk��
             backDistance = CheckWallDistance(transform.right);*/
            a = 1;
            b = 0;
        }
        else
        {
            b = 1;
        }

        switch (a)
        {
            case 0:
                // ���e��
                frontDistance = CheckWallDistance(transform.forward);

                // �����
                backDistance = CheckWallDistance(-transform.forward);

                // ����
                leftDistance = CheckWallDistance(-transform.right);

                // �k��
                rightDistance = CheckWallDistance(transform.right);
                break;
            case 2:
                // ��180�׫᥿�e��
                backDistance = CheckWallDistance(transform.forward);
                // ��180�ץ����
                frontDistance = CheckWallDistance(-transform.forward);
                // ��180�ץ���
                rightDistance = CheckWallDistance(-transform.right);
                // ��180�ץk��
                leftDistance = CheckWallDistance(transform.right);
                break;
            case 3:
                // ��270�ץ��e��
                leftDistance = CheckWallDistance(transform.forward);
                // ��270�ץ����
                rightDistance = CheckWallDistance(-transform.forward);
                // ��270�ץ���
                backDistance = CheckWallDistance(-transform.right);
                // ��270�ץk��
                frontDistance = CheckWallDistance(transform.right);
                break;
            case 1:
                // ��90�ץ��e��
                rightDistance = CheckWallDistance(transform.forward);
                // ��90�ץ����
                leftDistance = CheckWallDistance(-transform.forward);
                // ��90�ץ���
                frontDistance = CheckWallDistance(-transform.right);
                // ��90�ץk��
                backDistance = CheckWallDistance(transform.right);
                break;
            }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && b == 1)
        {
            /*c=transform.eulerAngles.y;
            for (int i = 0; i <= 90; i++)
            {
                transform.Rotate(0, +1, 0);
            }
            transform.rotation = Quaternion.Euler(0,c+90, 0);*/
            cycle = 1;
            if (a!=3) a++;
            else
                a=0;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && b == 1)
        {
            /*c = transform.eulerAngles.y;
            for (int i = 1; i <= 90; i++)
            {
                transform.Rotate(0, -1, 0);
            }
            transform.rotation = Quaternion.Euler(0, c - 90, 0);*/
            cycle = 2;
            if (a != 0) a--;
            else
                a = 3;
        }
    }
}