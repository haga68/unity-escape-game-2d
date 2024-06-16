using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaServer : MonoBehaviour
{
    //�N���b�N���ꂽ�Ƃ�
    //�^�k�L������΁A�����Ȃ�
    //�^�k�L�����Ȃ���΁A�ړ��i������j

    public Tanuki tanuki;//���ʂ��̏����擾
    Animation anim;
    bool moved = false;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    //���łɓ������Ă���Ȃ����
    private void Start()
    {
        //���łɃN���A���Ă���Ȃ�
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.MovedTeaServer);
        if (clearGimmick == true)
        {
            Moved();//�ŏ�����A���̈ʒu�Ɉړ������Ă���
        }
    }
    void Moved()
    {
        moved = true;
        transform.localPosition = new Vector3(-22, -71, 0);
    }
    void Move()
    {
        moved = true;
        anim.Play();
        //    gameObject.SetActive(false);//�e�B�[�T�[�o�[��������
    }

    public void OnThis()
    {
        //���łɈړ����Ă���Ȃ�A���������Ȃ�
        if(moved==true)
        {
            return;
        }

        bool movedTanuki = tanuki.moved; //���ʂ��������Ă��邩�ǂ���
        if (movedTanuki == true)
        {
            AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
            SaveManager.instance.SetGimmickFlag(SaveManager.Flag.MovedTeaServer);
            Move();
        }
        else
        {
            MessageManager.instance.ShowMessage("�^�k�L�����ē������Ȃ�");
        }
    }

}
