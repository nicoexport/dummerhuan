using Dummerhuan.Combat;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Dummerhuan.Events.Game_Events
{
	[System.Serializable]
	[CreateAssetMenu(
	    fileName = "EnemySOGameEvent.asset",
	    menuName = SOArchitecture_Utility.GAME_EVENT + "Enemy",
	    order = 120)]
	public sealed class EnemySOGameEvent : GameEventBase<EnemySO>
	{
	}
}