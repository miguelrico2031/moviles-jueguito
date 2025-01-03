using System.Collections.Generic;
using UnityEngine;

public abstract class ADay : ScriptableObject
{
    public abstract int MinigamesCount { get; protected set; }
    
    [field: SerializeField] public Dialogue DialogueBefore { get; private set; }
    [field: SerializeField] public Dialogue DialogueAfter { get; private set; }
    [field: SerializeField] public List<CharacterBucket> Buckets { get; private set; }
    [field: SerializeField] public bool SkipNonUniqueBuckets { get; private set; }
    
    public abstract IEnumerable<Minigame> GetMinigames();
}