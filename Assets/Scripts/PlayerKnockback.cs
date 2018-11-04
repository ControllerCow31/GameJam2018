using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour {

    public IEnumerator Knockback(float knockBackDuration, float knockBackPower, Vector2 knockBackDirection) {
        float timer = 0;

        while (knockBackDuration > timer) {
            timer += Time.deltaTime;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(knockBackDirection.x * -100, knockBackDirection.y * knockBackPower));
        }

        yield return null;

    }
}
