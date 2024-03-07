using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject[] shooter; // ���� ���� ������Ʈ�� �޴� ���� ��
    [SerializeField] private bool isGameOverChecked; // üũ ǥ�� Ȱ��ȭ ���ο� ���� �����ϴ� �޼ҵ尡 �޶����� ����

    private void Update() // ������Ʈ �޼ҵ�
    {
        OnCheckGameOver(isGameOverChecked); // ���� ������ Ȯ���ϴ� �޼ҵ�
    }

    private void OnCheckGameOver(bool _isChecked) // ���� ������ Ȯ���ϴ� �޼ҵ�
    {
        if (_isChecked == false)
        {
            return;
        }

        bool _isCleared = true; // ���� ������ Ȯ���ϴ� �� or ������ �Ҹ��� ���� ������ �����Ѵ�

        for (int i = 0; i < shooter.Length; ++i) // ���� ���� ������Ʈ�� ���� ��ŭ �ݺ��ϴ� �ݺ���
        {
            _isCleared &= !shooter[i].activeSelf; // ���� ���� �Ҹ��� ���� ��� ���� ��쿡 ������ ��ȯ�Ѵ�
        }

        if (_isCleared) // ���� ���� �Ҹ��� ���� ���� ���
        {
            SceneManager.LoadScene("GameOver"); // ���� ���� ���� �ε��Ѵ�
        }
    }
}
