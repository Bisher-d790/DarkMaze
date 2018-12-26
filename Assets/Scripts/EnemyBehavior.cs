using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class EnemyBehavior : MonoBehaviour
{
    // explosion when hit?
    public AudioClip AttackSFX;
    public AudioClip BreathSFX;

    private void Update()
    {
        if (BreathSFX)
        {
            if (!this.gameObject.GetComponent<AudioSource>().isPlaying) { this.gameObject.GetComponent<AudioSource>().PlayOneShot(BreathSFX); }
        }
    }

    // when collided with another gameObject
    void OnCollisionEnter(Collision newCollision)
    {
        
        if (AttackSFX)
        {
            this.gameObject.GetComponent<AudioSource>().Stop();
            this.gameObject.GetComponent<AudioSource>().volume = 1f;
            this.gameObject.GetComponent<AudioSource>().PlayOneShot(AttackSFX);
        }

        this.GetComponent<Animator>().SetTrigger("isHit");
        StartCoroutine(KillPlayer(1.2f));
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

