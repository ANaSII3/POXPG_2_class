using UnityEngine;


public class DoorTrigger : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private OpenDoor10c door; // —сылка на дверь

    private void OnTriggerEnter2D(Collider2D collision)
    {
        anim.SetBool("IsOpen", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("IsOpen", false);    
    }
}