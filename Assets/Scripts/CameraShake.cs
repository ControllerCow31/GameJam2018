using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public IEnumerator Shake(float duration, float magnitude) {
        Vector3 originalPos = transform.localPosition;

        float elapsedTime = 0;

        while (elapsedTime < duration) {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPos.z);

            elapsedTime += Time.deltaTime;

            //Wait until next frame before continuing loop
            yield return null;
        }

        //Reset
        transform.localPosition = originalPos;
    }
}
