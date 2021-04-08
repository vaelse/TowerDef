using UnityEngine;

public class CastleHealthLoss : MonoBehaviour
{
    public GameObject healthBar;
    TextMesh CastleTextMesh;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Spawn.aliveMonsterCount--;
            CastleDamaged();
            Destroy(collision.gameObject);
        }
    }

    public void CastleDamaged()
    {
        //remove one character from TextMesh
        CastleTextMesh = healthBar.GetComponent<TextMesh>();
        CastleTextMesh.text = CastleTextMesh.text.Remove(CastleTextMesh.text.Length - 1);
    }
}
