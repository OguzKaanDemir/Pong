using UnityEngine;

public class Boost : MonoBehaviour
{
    public float duration;
    public PlayerController Player
    {
        get
        {
            if (!Player)
                Player = FindObjectOfType<PlayerController>();
            return Player;
        }
        private set { }
    }

    /*private void Start()
        => Destroy(this.gameObject, 5);*/

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public virtual void DoAction(BallMovement ball)
    {
        Destroy(gameObject, .1f);
    }

    private void OnDestroy()
       => FindObjectOfType<BoostSpawner>().StartSpawn();
}
