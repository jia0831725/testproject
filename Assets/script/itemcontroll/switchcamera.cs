using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchcamera : MonoBehaviour
{
    private switchitemusing positionplace; //偵測選擇框在哪個位置
    public GameObject player,freecam,choosequare,playercam;
    public float timeDelay = 20f;
    // Start is called before the first frame update
    void Start()
    {
        positionplace = choosequare.GetComponent<switchitemusing>();
    }

    // Update is called once per frame
    void Update()
    {
        if(positionplace.switchitem % 7 == 0 &&　Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine(Camerausing());
        }    
    }

    IEnumerator Camerausing()
    {
        player.GetComponent<PlayerMovement>().enabled = false;
        player.GetComponent<rotationchanging>().enabled = false;
        freecam.SetActive(true);
        playercam.SetActive(false);
        yield return new 
       WaitForSeconds(timeDelay);
        player.GetComponent<PlayerMovement>().enabled = true;
        player.GetComponent<rotationchanging>().enabled = true;
        freecam.transform.position = player.transform.position + new Vector3(8, 8, -8);
        freecam.transform.LookAt(player.transform);
        freecam.SetActive(false);
        playercam.SetActive(true);
    }
}
