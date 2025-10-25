using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;        // ���ʳt��
    public float jumpHeight = 2f;   // ���D����
    public float gravity = -9.8f;   // ���O
    private float ySpeed = 0f;      // �����t�ס]�Ψ��x�s���D�M���O�v�T�^
    private CharacterController controller;
    private bool isGrounded;        // �˴��O�_�b�a���W

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // �ˬd�O�_�b�a���W
        isGrounded = controller.isGrounded;

        // �˴��O�_���U���D��]�Ҧp�ť���^
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);  // �ھڭ��O�p����D�t��
            }
            else
            {
                ySpeed = -1f;  // �b�a���W�ɫO���@�Ӥp���t�ȡA�קK����Q�y�L�����a��
            }
        }

        // ���έ��O
        if (!isGrounded)
        {
            ySpeed += gravity * Time.deltaTime;  // �C��W�[���O�v�T
        }

        // Ū�����a��������J
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // �p�⪱�a�����ʤ�V�]�u���� X �M Z ���С^
        Vector3 move = transform.right * moveX+ transform.forward * moveZ;
        move.y = ySpeed;  // �N������V���t�ס]���O�θ��D�^���Ψ첾��

        // ���ʨ���
        controller.Move(move * speed * Time.deltaTime);
    }
}
