using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public NextPlanetManager nextPlanetManager; // NextPlanetManager�� �ִ� isSpriteChanged �Ҹ��� ������ �����ϱ� ���� ���
    public GameObject[] planetPrefab; // 1�������� 3���� ������ ���� �༺�� �����Ͽ� �߻��ϱ� ���� ������
    public int currentNumber; // ���� �� 1 ~ 3���� ������ ���� �༺�� �ε��� ���� ���� ���� ����

    [SerializeField] private Transform spawnPoint; // ������ ���� ����Ʈ�� �༺�� �߻��ϱ� ���� ������ �Ǵ� ��ǥ

    [SerializeField] private float shooterSpeed = 30f; // ���͸� ���콺�� �̵����� ��, �ӵ� �Ǽ� ��
    [SerializeField] private float shootPower = 500f; // ���ͷ� ��ƿø� �༺�� �� ũ�� �Ǽ� ��

    private float shooterRange = 4.3f; // 2D ȯ�濡���� 2���� x, y ��ǥ �� x ��ǥ�� ���� ������ �̵� ���� ������ ���� ���� �Ǽ� ��

    private void Start()
    {

    }

    private void Update()
    {
        OnMouseCursor(); // ���콺 Ŀ���� �Է¹޴� �޼ҵ�
        OnMouseInput(); // ���콺 ��ư�� �Է¹޴� �޼ҵ�
    }

    private void OnMouseCursor() // ���콺 Ŀ�� �Է��� ���� ���͸� �̵���Ű�� �޼ҵ�
    {
        float _horizontal = Input.GetAxis("Mouse X"); // Mouse X => (���� Ű���� �Է��̸�...) Horizontal, ���콺 Ŀ�� �Է� �Ǽ� ��
        float _speed = _horizontal * Time.deltaTime * shooterSpeed; // ������ �ӵ��� �ð� ������ �����̱� ���� ��

        transform.Translate(new Vector3(_speed, 0, 0)); // ���Ͱ� �¿�θ� �̵��Ͽ��� �ϱ� ������ x������ ���ǵ带 �����ϰ� y,z���� �����ǰ� 0���� ������

        if (transform.position.x > shooterRange) // ������ x��ǥ���� shooterRange���� Ŭ��
        {
            transform.position = new Vector3(shooterRange, transform.position.y, 0); // ������ ��ġ�� shooterRange��ǥ�� ������ y��ǥ z = 0 ���� �����Ѵ�
        }
        if (transform.position.x < -shooterRange) // ������ -x��ǥ���� shooerRange���� ������
        {
            transform.position = new Vector3(-shooterRange, transform.position.y, 0); // ������ ��ġ�� shooterRange��ǥ�� ������ y��ǥ z = 0 ���� �����Ѵ� 
        }
    }

    private void OnMouseInput() // ���콺 ��,���ư �Է¹޴� �޼ҵ�
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // ���콺 ���� ��ư�� ������ ��
        {
            OnShoot(); // �߻��ϴ� �޼ҵ带 ȣ���Ѵ�
        }
    }

    private void OnShoot() // �߻��ϴ� �޼ҵ�
    {
        GameObject _planet = Instantiate(planetPrefab[currentNumber], spawnPoint.position, spawnPoint.rotation);
        // ���ӿ�����Ʈ�� �༺�� �༺������ 1~3���� ��������Ʈ ��ǥ�� ��������Ʈ ��(ȸ����)���� �����Ѵ�

        _planet.tag = "Untagged"; // �༺�� �±״� Untagged(�±׾���)
        _planet.GetComponent<Rigidbody2D>().AddForce(_planet.transform.up * shootPower);
        // �༺ ���� ������Ʈ���� ������ٵ�2D ������Ʈ�� �ҷ��� �� �༺�� �������� �������� shootPower ��ŭ�� ���� ���Ѵ�

        nextPlanetManager.isSpriteChanged = true; 
        currentNumber = UnityEngine.Random.Range(0, planetPrefab.Length); //1~3���� �༺�� �����ϰ� �����ϱ� ���� 0���� �������� ���� ������ ���� ���� ��ȯ
    }
}
