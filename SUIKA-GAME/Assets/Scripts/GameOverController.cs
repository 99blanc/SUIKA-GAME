using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject[] shooter; // 슈터 게임 오브젝트를 받는 변수 값
    [SerializeField] private bool isGameOverChecked; // 체크 표시 활성화 여부에 따라 동작하는 메소드가 달라지는 변수

    private void Update() // 업데이트 메소드
    {
        OnCheckGameOver(isGameOverChecked); // 게임 오버를 확인하는 메소드
    }

    private void OnCheckGameOver(bool _isChecked) // 게임 오버를 확인하는 메소드
    {
        if (_isChecked == false)
        {
            return;
        }

        bool _isCleared = true; // 게임 오버를 확인하는 참 or 거짓인 불리언 값을 참으로 설정한다

        for (int i = 0; i < shooter.Length; ++i) // 슈터 게임 오버젝트의 개수 만큼 반복하는 반복문
        {
            _isCleared &= !shooter[i].activeSelf; // 게임 오버 불리언 값이 모두 참일 경우에 참으로 반환한다
        }

        if (_isCleared) // 게임 오버 불리언 값이 참일 경우
        {
            SceneManager.LoadScene("GameOver"); // 게임 오버 씬을 로드한다
        }
    }
}
