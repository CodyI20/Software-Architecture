using UnityEngine;

[CreateAssetMenu(menuName = "Tower Defense/Command")]
public class CommandSO : ScriptableObject
{
    public virtual void Execute(TowerStats tower) { }
    public virtual void Undo(TowerStats tower) { }
}
