using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{

    public int SelectedWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();    
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedWeapon = SelectedWeapon;
        ChangeWeaponOnTilde();
        ChangeWeaponOnKeyPress();

        if (previousSelectedWeapon != SelectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == SelectedWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }

    void ChangeWeaponOnKeyPress()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            SelectedWeapon = 0;
        }
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            SelectedWeapon = 1;
        }
    }
    void ChangeWeaponOnTilde()
    {
        if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            if (SelectedWeapon >= transform.childCount - 1)
            {
                SelectedWeapon = 0;
            }
            else
            {
                SelectedWeapon++;
            }
        }
    }
    void ChangeWeaponOnScroll()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (SelectedWeapon >= transform.childCount - 1)
            {
                SelectedWeapon = 0;
            }
            else
            {
                SelectedWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (SelectedWeapon <= 0)
            {
                SelectedWeapon = transform.childCount - 1;
            }
            else
            {
                SelectedWeapon--;
            }
        }
    }
}
