using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getitemvisible : MonoBehaviour
{
    private getitem jump;
    public int jumpi = 1;
    public Vector3[] itemplace;
    public int itemnumber,save,load; //��o����,�s��U��m,�^�ǭ��m
    public GameObject jumpitem,sort;
    public GameObject jumpbuff; //�O�_��o���~
    private switchitemusing hieght;
    // Start is called before the first frame update
    void Start()
    {
        itemplace = new Vector3[6]{
        new Vector3(177, -59, 0),
        new Vector3(241, -59, 0),
        new Vector3(305, -59, 0),
        new Vector3(370, -59, 0),
        new Vector3(434, -59, 0),
        new Vector3(498, -59, 0) };
        jump = jumpbuff.GetComponent<getitem>();
        itemnumber = 0;
        hieght = sort.GetComponent<switchitemusing>();
    }

    // Update is called once per frame
    void Update()
    {
        //��o���~���
        if(jump.activejump == 0 && jumpi == 1 && itemnumber < 6)
        {
            jumpitem.SetActive(true);   
            jumpitem.transform.position = itemplace[itemnumber];
            if(hieght.heightfollow)
            {
                jumpitem.transform.position += new Vector3(0, 120, 0);
            }
            jumpi = itemnumber;
            itemnumber ++;
            load = 1;
            jumpitem.transform.SetParent(transform);

            if(transform.position.y >= 65)
            {
                jumpitem.transform.position += new Vector3(0,110,0);
            }
        }
        //..........


        //���~����
        if(jumpi != 1 && jump.activejump == 1)
        {
            save = itemnumber;
            itemnumber = jumpi;
        }


        //���~�ɤW�Ŧ�ᶶ�Ƿ���
        if(load == 1)
        {
            if(save != 0)
            {
                itemnumber = save;
            }
            save = 0;
        }
    }
}
