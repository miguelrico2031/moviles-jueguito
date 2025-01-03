using UnityEngine;

public class BouncyPinScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pachinko Ball"))
        {
            Vibrate();
        }
    }
    private void Vibrate()
    {
#if UNITY_ANDROID || UNITY_IOS
        Handheld.Vibrate();
#endif
    }
}
