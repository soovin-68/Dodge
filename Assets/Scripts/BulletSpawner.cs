using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab; // 생성할 총알의 원본 프리맵
    public float spawnRateMin = 0.5f; // 최소 생성 주기
    public float spawnRateMax = 3f; // 최대 생성 주기

    private Transform target; // 발사할 대상
    private float spawnRate; // 생성 주기
    private float timeAfterSpawn; // 최근 생성 시점에서 지난 시간
    private AudioSource spawnSource; // 총알 발사 소리 재생을 위한 오디오 소스
    public AudioClip spawnClip; // 총알 발사 소리 클립

    void Start()
    {
        // 최근 생성 이후의 누적 시간을 0으로 초기화
        timeAfterSpawn = 0f;
        // 총알 생성 간격을 spawnRateMin과 spawnRateMax 사이의 랜덤 값으로 설정
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // playerController 컴폰전트를 가진 게임 오브젝트를 찾아 조준 대상으로 설정
        target = FindFirstObjectByType<PlayerController>().transform;
        spawnSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        //timeAfterSpawn을 갱신
        timeAfterSpawn += Time.deltaTime;

        //최근 생성 시점에서부터 누적된 시간이, 생성 주기보다 크거나 같아면
        if (timeAfterSpawn >= spawnRate)
        {
            spawnSound.PlayOneShot(spawnClip);
            //누적된 시간을 리셋
            timeAfterSpawn = 0f;
            //bulletPrefab의 복사본을
            //transform.position 위치와 transform.rotation 회전으로 생성
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            //생성된 bullet 게임 오브젝트의 정면 방향이 target을 향하도록 회전
            bullet.transform.LookAt(target);

            //다음번 생성 간격을 spawnRateMin, spawnRateMax 사이에서 랜덤 지정
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }

}
