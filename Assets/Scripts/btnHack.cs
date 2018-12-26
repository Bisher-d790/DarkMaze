using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnHack : MonoBehaviour {

    [SerializeField] GameObject mainCvns;
    [SerializeField] GameObject creditCnvs;

    public void Update()
    {

        if (Input.GetButtonDown("Choose"))
        {

            creditCnvs.SetActive(false);
            mainCvns.SetActive(true);

        }

    }
}
