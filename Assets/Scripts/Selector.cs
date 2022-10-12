using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    public void SetRotation(int d) {  transform.localRotation = Quaternion.Euler(0, 0, d); }
}
