using System.Collections;
using UnityEngine;

public class ShooterAnimationController : MonoBehaviour
{
    [SerializeField] private GameObject shooter; // ���� ���� ������Ʈ�� �����ϴ� ���� ��
    [SerializeField] private float animationDelay = 2f; // �ִϸ��̼� �����̸� �����ϴ� �Ǽ� ��
    [SerializeField] private float shooterInitDelay = 1.4f; // ���� ���� �����̸� �����ϴ� �Ǽ� ��

    private float fixShooterYValue = 0.09f; // ���� Y ��ǥ�� �����ϴ� �Ǽ� ��
    private Vector3 value = Vector3.zero; // Vactor3.SmoothDamp�� ���� Vector3 ��
    private bool isLanded; // ���Ͱ� �����ߴ��� Ȯ���ϴ� �� or ������ �Ҹ��� ��

    private void Start() // ��ŸƮ �޼ҵ�
    {
        OnShooterAnimationInit(true); // ���� ���� �޼ҵ� ���� �����δ� Ȱ��ȭ ���θ� Ȯ���ϴ� �� or ������ �Ҹ��� ���� �޴´�
    }

    private void OnShooterAnimationInit(bool _isActived) // ���� ���� �޼ҵ� ���� �����δ� Ȱ��ȭ ���θ� Ȯ���ϴ� �� or ������ �Ҹ��� ���� �޴´�
    {
        shooter.SetActive(!_isActived); // ���� ���� ������Ʈ�� ���ڰ����� �ݴ밪���� �����Ѵ�
        gameObject.SetActive(_isActived); // ���� ���ϸ��̼� ���� ������Ʈ�� ���ڰ����� �����Ѵ�
        SoundManager.Play.PlayEffect("ShooterTakeoff"); // ���� �̸����� ���� ���
    }

    private void Update() // ������Ʈ �޼ҵ�
    {
        OnAnimationTranslate(); // �ִϸ��̼� �̵� �޼ҵ�
    }

    private void OnAnimationTranslate() // �ִϸ��̼� �̵� �޼ҵ�
    {
        if (isLanded == false && transform.position == shooter.transform.position)
            // ���� ���°� �ƴϰų� ���� ���ϸ��̼� ���� ������Ʈ�� ��ġ�� ���� ���ӿ�����Ʈ�� ��ġ�� ���ٸ�
        {
            isLanded = true; // ���� ���¸� ������ �����Ѵ�
            StartCoroutine(OnShooterInitDelay(false)); // ���� ���� ������ �ڷ�ƾ�� ���� ���� �������� �Ͽ� �ڷ�ƾ�� �����Ѵ�
        }

        if (transform.position.y <= shooter.transform.position.y + fixShooterYValue)
            // ���� �ִϸ��̼� ���� ������Ʈ ������ y ���� ���� ���� ������Ʈ y���� ���� ���� ���Ѱ� ���� �۰ų� ���� ��
        {
            transform.position = shooter.transform.position; // ���� �ִϸ��̼� ���� ������Ʈ�� ��ġ�� ���� ���� ������Ʈ�� ��ġ�� �����Ѵ�
            transform.rotation = Quaternion.Slerp(transform.rotation, shooter.transform.rotation, animationDelay * Time.deltaTime);
            // ���� �ִϸ��̼� ���� ������Ʈ�� ȸ�� ���� Slerp �Լ��� �̿��� �ε巴�� �����Ѵ�
        }
        else // ���� �ٸ���
        {
            transform.position = Vector3.SmoothDamp(gameObject.transform.position, shooter.transform.position, ref value, animationDelay);
            // ���� �ִϸ��̼��� ��ġ ���� ���� ������ �Ͽ� SmoothDamp �Լ��� �̿��� �ε巴�� �̵���Ų��
        }
    }

    private IEnumerator OnShooterInitDelay(bool _isActived)
        // ���� ���� ������ �ڷ�ƾ �޼ҵ�� ���� �����δ� Ȱ��ȭ ������ �� or ���� �Ҹ��� ���� �޴´�
    {
        SoundManager.Play.PlayEffect("ShooterLand"); // ���� �̸����� ���� ���

        yield return new WaitForSeconds(shooterInitDelay / 2); // shooterInitDelay / 2 �Ǽ� �� ��ŭ �ʴ� ������ ��Ų��

        SoundManager.Play.PlayEffect("GameStart"); // ���� �̸����� ���� ���

        yield return new WaitForSeconds(shooterInitDelay / 2); // shooterInitDelay / 2 �Ǽ� �� ��ŭ �ʴ� ������ ��Ų��

        shooter.SetActive(!_isActived); // ���� ���� ������Ʈ�� Ȱ��ȭ ���¸� ���� ���� �ݴ� ������ �����Ѵ�
        gameObject.SetActive(_isActived); // ���� �ִϸ��̼� ���� ������Ʈ�� Ȱ��ȭ ���¸� ���� ������ �����Ѵ�
    }
}
