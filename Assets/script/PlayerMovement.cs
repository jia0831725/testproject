using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;        // 移動速度
    public float jumpHeight = 2f;   // 跳躍高度
    public float gravity = -9.8f;   // 重力
    private float ySpeed = 0f;      // 垂直速度（用來儲存跳躍和重力影響）
    private CharacterController controller;
    private bool isGrounded;        // 檢測是否在地面上

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // 檢查是否在地面上
        isGrounded = controller.isGrounded;

        // 檢測是否按下跳躍鍵（例如空白鍵）
        if (isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);  // 根據重力計算跳躍速度
            }
            else
            {
                ySpeed = -1f;  // 在地面上時保持一個小的負值，避免角色被稍微推離地面
            }
        }

        // 應用重力
        if (!isGrounded)
        {
            ySpeed += gravity * Time.deltaTime;  // 每秒增加重力影響
        }

        // 讀取玩家的水平輸入
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 計算玩家的移動方向（只改變 X 和 Z 坐標）
        Vector3 move = transform.right * moveX+ transform.forward * moveZ;
        move.y = ySpeed;  // 將垂直方向的速度（重力或跳躍）應用到移動

        // 移動角色
        controller.Move(move * speed * Time.deltaTime);
    }
}
