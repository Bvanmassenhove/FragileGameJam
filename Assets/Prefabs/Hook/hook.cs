using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hook : MonoBehaviour
{
	private Rigidbody2D rb;
	private bool hooking = false;
	private bool hooked = true;
	[SerializeField] private float hookspeed;
	[SerializeField] private float retractspeed;
	[SerializeField] private Rigidbody2D player;

    public float checkRadius;
    public LayerMask whatIsPlatform;

	bool M1 = false;

    // Start is called before the first frame update
    void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (!hooking)
		{
			rb.transform.position = player.transform.position;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 slingPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ShootSling(slingPos);
			M1 = true;
		}

        if (Input.GetMouseButtonDown(1))
		{
			Vector3 slingPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ShootSling(slingPos);
		}

        if (!Input.GetMouseButton(0) && !Input.GetMouseButton(1))
        {
            RetractSling();
			M1 = false;

		}

        if (Physics2D.OverlapCircle(rb.position, checkRadius, whatIsPlatform))
        {
			hooked = true;
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}

		if (hooked && M1)
		{
			Vector3 toHook = rb.transform.position - player.transform.position;
			player.velocity = toHook.normalized * retractspeed;
		}
	}

	void ShootSling(Vector3 slingPos)
	{
		hooking = true;
		Vector3 toHook = slingPos - player.transform.position;
		rb.velocity = toHook * hookspeed;
	}

	void RetractSling()
	{
		hooking = false;
		hooked = false;
		rb.constraints = RigidbodyConstraints2D.None;
	}
}
