using UnityEngine;

public class Boost : MonoBehaviour
{
    public float duration;

    private void Start()
        => Destroy(this.gameObject, 5);

    private void Awake()
    {
        GameManager.Ins.onNewRound += DestroyGO;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public virtual void DoAction(BallMovement ball)
    {
        DestroyGO();
    }

    private void DestroyGO()
    {
        Destroy(gameObject, .1f);
    }

    private void OnDestroy()
    {
        FindObjectOfType<BoostSpawner>().StartSpawn();
        GameManager.Ins.onNewRound -= DestroyGO;
    }
}
