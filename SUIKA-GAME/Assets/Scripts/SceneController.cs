using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void OnStartClick() // ��ŸƮ ��ư�� ������ ���� �޼ҵ�
    {
        SceneManager.LoadScene("Ingame"); // �ΰ��� ���� �ε��Ѵ�
    }

    public void OnOptionClick() // �ɼ� ��ư�� ������ ���� �޼ҵ�
    {
        SceneManager.LoadScene("Option"); // �ɼ� ���� �ε��Ѵ�
    }

    public void OnQuitClick() // ���� ��ư�� ������ ���� �޼ҵ�
    {
        Application.Quit(); // ���� ���α׷��� ��� �����Ѵ�
    }
}
