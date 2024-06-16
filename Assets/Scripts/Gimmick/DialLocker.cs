using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialLocker : MonoBehaviour
{
    //�O�̃{�^�������ꂼ��N���b�N���ĊG�������ׂĈ�v����΃N���A

    //�{�^���̉摜���擾
    public Image[] buttons;
    //�\������}�[�N���
    enum Mark
    {
        Maru,
        Sankaku,
        Hoshi,
        Daia
    }
    //���݂̃}�[�N
    Mark[] currentMarks = { Mark.Maru, Mark.Maru, Mark.Maru };
    Mark[] correctAnswerMarks = { Mark.Maru, Mark.Sankaku, Mark.Hoshi };

    //�\������摜�̑f�ވꗗ
    public Sprite[] resourceSprites;
    //(�O���̊֐���ݒ肵�����ꍇ)UnityEvent���g��
    public UnityEvent ClearEvent;

    public void OnMarkButton(int position) //�{�^�����N���b�N������
    {        
        ChangeMark(position);           //�iposition�́j�}�[�N��ύX����
        ShowMark(position);             //�摜��\��

        //�N���A���邩�ǂ����`�F�b�N
        if(IsAllClearMark() == true) //�S���A��v���Ă�����
        {
            Clear();                            //�N���A
        }
    }
    void ChangeMark(int position)
    {
        currentMarks[position]++; //����̃}�[�N��
        if (currentMarks[position] > Mark.Daia) 
        {
            currentMarks[position] = Mark.Maru;
        }
    }

    void ShowMark(int position)
    {
        int index = (int)currentMarks[position]; //int��
        buttons[position].sprite = resourceSprites[index]; //�Ή�����摜��\��
    }

    //�S���A��v���Ă��邩�ǂ���
    bool IsAllClearMark()
    {
        for (int i = 0;i < currentMarks.Length; i++)
        {
            if (currentMarks[i] != correctAnswerMarks[i])
            {                
                return false;   //��ł��Ⴄ���̂������false
            }
        }
        return true; //���ׂĈ�v���Ă�����N���A
    }
    void Clear()
    {
        AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
        MessageManager.instance.ShowMessage("���b�J�[���J����");
        ClearEvent.Invoke();    //UnityEvent�𔭓�
    }  
}
