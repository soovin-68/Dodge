using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;  // 이동 속도
    private Rigidbody playerRigidbody;  // Rigidbody 변수

    // Start는 처음 한 번 실행됨
    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody 변수에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // 매 프레임마다 실행됨
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // 위쪽 방향키 입력이 감지된 경우 z 방향으로 힘 가하기
            playerRigidbody.AddForce(0f, 0f, speed);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            // 아래쪽 방향키 입력이 감지된 경우 -z 방향으로 힘 가하기
            playerRigidbody.AddForce(0f, 0f, -speed);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            // 오른쪽 방향키 입력이 감지된 경우 x 방향으로 힘 가하기
            playerRigidbody.AddForce(speed, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // 왼쪽 방향키 입력이 감지된 경우 -x 방향으로 힘 가하기
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
    }
}
