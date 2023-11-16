using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text scoreText; // ���ھ� �ý�Ʈ ������ ���� �ؽ�Ʈ ���� ��
    public static Text scoreValue; // ���ھ� ������ �ý�Ʈ ������ ���� �ý�Ʈ ���� ��
    public static int score; // ���ھ� ���� ���� ��

    private void Start()
    {
        OnScoreText();
    }

    private void OnScoreText()
    {
        score = PlayerPrefs.GetInt("Score");
        scoreValue = GetComponent<Text>();
        PlayerPrefs.SetString("IsScored", "true");
        OnSetScore(score);
    }

    public static void OnSetScore(int _score) // ���ھ� ���� ���� �޼ҵ�
    {
        if (PlayerPrefs.GetString("IsScored").Equals("true"))
        {
            score = _score;
            scoreValue.text = score.ToString();
            PlayerPrefs.SetString("IsScored", "false");
        }
        else if (PlayerPrefs.GetString("IsScored").Equals("false"))
        {
            score += _score; // �� ��ũ��Ʈ�� ���ھ� ���� ���� ���� _score ���� ������ ���Ѵ�
            scoreValue.text = score.ToString();
            // ���ھ� ������ �ؽ�Ʈ ������Ʈ�� ������ �� �ؽ�Ʈ�� ���ھ�� ���ڿ� ����ȯ ��Ų��
        }
    }
}
