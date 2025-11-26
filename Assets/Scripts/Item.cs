using UnityEngine;

public abstract class item : MonoBehaviour
{
    [field: SerializeField] protected int ItemValue { get; set; }

    public abstract void Use(Player player);

    public void Pickup(Player player)
    {
        Use(player);
        Destroy(this);
    }
}
