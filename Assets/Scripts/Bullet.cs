using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;  // 총알 속도
    private Rigidbody bulletRigidbody;  // 이동에 사용할 리지드바디 컴포넌트

    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody 변수에 할당
        bulletRigidbody = GetComponent<Rigidbody>();

        // 리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.linearVelocity = transform.forward * speed;

        // 3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }

    // 트리거 충돌시 자동으로 실행되는 매서드
    void OnTriggerEnter(Collider other)
    {

        // 상대방 게임 오브젝트에서 PlayerController 컴포넌트를 가져오기
        PlayerController playerController
            = other.GetComponent<PlayerController>();

        // 상대방으로부터 PlayerController 컴포넌트를 가져오는데 성공했다면
        if (playerController != null)
        {

            //상대방 PlayerController 컴포넌트의 Die() 매서드 실행
            playerController.Die();

        }
    }
}