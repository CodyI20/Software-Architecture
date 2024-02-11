using UnityEngine;

[CreateAssetMenu(menuName = "Tower Defense/Command")]
public class CommandSO : ScriptableObject
{
    public int cost;
    public virtual void Execute(AbstractTower tower) { }
    public virtual void Undo(AbstractTower tower) { }
}
