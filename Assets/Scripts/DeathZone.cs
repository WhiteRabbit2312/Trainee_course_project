using UnityEngine;

namespace TraineeGame
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "DeathZone")
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
