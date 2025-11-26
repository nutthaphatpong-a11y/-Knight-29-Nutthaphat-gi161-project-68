using UnityEngine;

public class Longsword : item
{
    public override void Use(Player player)
    {
        if (player)
        {
            player.putonLongSword(ItemValue);
            Destroy(this.gameObject);
        }
    }
}
