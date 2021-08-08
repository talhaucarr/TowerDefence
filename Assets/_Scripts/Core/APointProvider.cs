using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class APointProvider : MonoBehaviour
{
    public abstract List<Transform> GetPointList();
}
