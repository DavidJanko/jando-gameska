using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public float fireballSpeed;

    public Transform firePoint;
    public GameObject fireballPrefab;
    public GameObject weaponAttachPoint;

    void Start()
    {
        //transform.parent = weaponAttachPoint.transform;
    }

    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);

        if (Input.GetMouseButtonDown(0))
        {
            ShootFireball();
        }
    }

    private void ShootFireball()
    {
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, transform.rotation);
        Rigidbody2D fireballRigidbody = fireball.GetComponent<Rigidbody2D>();
        fireballRigidbody.AddForce(firePoint.up * fireballSpeed, ForceMode2D.Impulse);
    }
}
