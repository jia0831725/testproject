using UnityEngine;

public class PlayerRespawnTrigger : MonoBehaviour
{
    private Vector3 respawnPoint = new Vector3(0, 0, 0);

    private void OnTriggerEnter(Collider other)
    {
        // 檢查是否碰到名為 "DeathZone" 的物件
        if (other.CompareTag("DeathZone"))
        {
            Respawn();
        }
    }

    void Respawn()
    {
        transform.position = respawnPoint;

        // 如果玩家有剛體，重置速度
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
