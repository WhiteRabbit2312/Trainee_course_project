using UnityEngine;

namespace TraineeGame
{
    public class DeathZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Obstacle")
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
