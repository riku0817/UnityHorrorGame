using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    Animation anime;
    DoorAnimation dooranimationscript;
    public bool animationbool = true;
    // Start is called before the first frame update
    void Start()
    {
        anime = this.gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    public void AnimationPlay()
    {
        // 暫定策：アニメーションを一回だけ再生
        if (animationbool == true)
        {
            anime.Play();
            animationbool = false;
        }


    }
}
