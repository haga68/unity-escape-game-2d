using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHydrant : MonoBehaviour
{
    public GameObject openObj;

    //�A�����͂̎���
    enum Direction
    {
        Left = 0,
        Right = 1
    }

    //Player�̓���
    List<Direction> userInputs = new List<Direction>();

    //�����̘A�����́i�E�A���A���A�E�A�E�j
    Direction[] correctAnswer =
    {
        Direction.Right,
        Direction.Left,
        Direction.Left,
        Direction.Right,
        Direction.Right,
    };

    private void Start()
    {
        //���łɃN���A���Ă���Ȃ�
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpenedFireHydrant);
        if (clearGimmick == true)
        {
            openObj.SetActive(true);
        }
    }

    //����
    public void OnButton(int type)
    {
        //type:0�@��
        //type:1�@�E
        if(type == 0)
        {
            userInputs.Add(Direction.Left);
        }
        if (type == 1)
        {
            userInputs.Add(Direction.Right);
        }
        Debug.Log(type);
        //���[�U�[�̓��͂���
        //5����͂��ꂽ��`�F�b�N����
        if(userInputs.Count == 5)
        {
            if(IsAllClear() == true)
            {
                Clear();
            }
            else
            {
                //�s��v�̏ꍇ�̎��� ���Z�b�g
                ResetInput();
            }
        }
    }
    void ResetInput()
    {
        MessageManager.instance.ShowMessage("���͂��Ԉ���Ă���悤��");
        userInputs.Clear();
        Debug.Log("���Z�b�g");
    }

    //��v���Ă��邩�`�F�b�N
    bool IsAllClear()
    {
        for (int i = 0; i < userInputs.Count; i++)
        {
            if (userInputs[i] != correctAnswer[i])
            {
                return false;
            }
        }
        return true;
    }
    void Clear()
    {
        AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
        Debug.Log("�N���A");
        SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpenedFireHydrant);
        openObj.SetActive(true);
        ItemBox.instance.UseItem(ItemManager.Item.Paper);   //���������i�����ŕt�������j
    }
}
