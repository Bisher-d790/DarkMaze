using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{

    public AudioClip SFX;
    public GameObject Enemy;

    void OnTriggerEnter(Collider Other)
    {

        if (Other.gameObject.tag == "Player")
        {
            Debug.Log("Player Collided");

            if (SFX)
            {
                Enemy.gameObject.GetComponent<AudioSource>().volume = 1f;
                Enemy.gameObject.GetComponent<AudioSource>().PlayOneShot(SFX);
            }
            if (Enemy)
            { Enemy.GetComponent<Animator>().SetTrigger("isHit"); }
            StartCoroutine(KillPlayer(1.2f));
        }
    }

    IEnumerator KillPlayer(float secs)
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlayerDeathSFX();
        yield return new WaitForSeconds(secs);

        /* if (GameManager.gm) // if the gameManager is available, tell it to reset the game
             GameManager.gm.ResetGame();
         else // otherwise, just reload the current level*/
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}


