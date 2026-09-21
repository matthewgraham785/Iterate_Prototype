using UnityEngine;

public class DataShardAnimation : MonoBehaviour
{
    [Header("Floating Movement")]
    [SerializeField] private float rotationSpeed = 55f;
    [SerializeField] private float bobHeight = 0.12f;
    [SerializeField] private float bobSpeed = 2f;

    [Header("Glitch Movement")]
    [SerializeField] private float glitchDistance = 0.035f;
    [SerializeField] private float glitchSpeed = 10f;

    private Vector3 startingPosition;

    private Transform fragmentA;
    private Transform fragmentB;

    private Vector3 fragmentAStart;
    private Vector3 fragmentBStart;

    private void Start()
    {
        startingPosition = transform.position;

        fragmentA = transform.Find("GlitchFragmentA");
        fragmentB = transform.Find("GlitchFragmentB");

        if (fragmentA != null)
        {
            fragmentAStart = fragmentA.localPosition;
        }

        if (fragmentB != null)
        {
            fragmentBStart = fragmentB.localPosition;
        }
    }

    private void Update()
    {
        transform.Rotate(
            Vector3.up,
            rotationSpeed * Time.deltaTime,
            Space.World
        );

        float bobMovement =
            Mathf.Sin(Time.time * bobSpeed) * bobHeight;

        transform.position =
            startingPosition + Vector3.up * bobMovement;

        float glitchMovement =
            Mathf.Sin(Time.time * glitchSpeed) * glitchDistance;

        if (fragmentA != null)
        {
            fragmentA.localPosition =
                fragmentAStart + Vector3.right * glitchMovement;
        }

        if (fragmentB != null)
        {
            fragmentB.localPosition =
                fragmentBStart
                + Vector3.left * glitchMovement
                + Vector3.up * glitchMovement * 0.5f;
        }
    }
}
