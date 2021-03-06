﻿using UnityEngine;
using System.Collections;

public static class Extensions{

    public static Vector3 AddRandomVector(this Vector3 vec, float offset)
    {
        return vec + new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset), Random.Range(-offset, offset));
    }

	public static Vector3 AddRandomVector2(this Vector3 vec, float offset)
	{
		return vec + new Vector3(Random.Range(-offset, offset), 0, Random.Range(-offset, offset));
	}
}
