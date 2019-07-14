using UnityEngine;

public class Bezier : MonoBehaviour {
    public Transform[] positions;
    private void OnDrawGizmos()
    {
        for(float i = 0.0f; i < 1.0f; i += 0.1f)
        {
            var gizmosPosition = Mathf.Pow(1.0f - i, 3) * positions[0].position +
                3* i* Mathf.Pow(1.0f - i, 2) * positions[1].position +
                3*i*i* Mathf.Pow(1.0f - i, 1) * positions[2].position +
                Mathf.Pow(i, 3) * positions[3].position;
            Gizmos.DrawSphere(gizmosPosition, 0.1f);
        }
    }
}
