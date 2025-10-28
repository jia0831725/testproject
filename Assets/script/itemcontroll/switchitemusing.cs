using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchitemusing : MonoBehaviour
{
    public int switchitem = 0;
    public bool heightfollow = false;
    private Vector3[] switchpos = new Vector3[7]
    {
        new Vector3(113,-62,0),
        new Vector3(177,-62,0),
        new Vector3(241,-62,0),
        new Vector3(305,-62,0),
        new Vector3(370,-62,0),
        new Vector3(434,-62,0),
        new Vector3(498,-62,0)
    };

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow) && transform.position.y - 47 <= 2 && transform.position.y - 47 >= -2)
        {
            switchitem++;
            transform.position = switchpos[switchitem % 7];
            if (heightfollow)
            {
                transform.position += new Vector3(0, 110, 0);
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.y- 47 <= 2 && transform.position.y - 47 >= -2)
        {
            if(switchitem == 0)
            {
                switchitem = 7;
            }
            switchitem--;
            transform.position = switchpos[switchitem % 7];
            if (heightfollow)
            {
                transform.position += new Vector3(0, 110, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            heightfollow = !heightfollow;
        }
    }
}
