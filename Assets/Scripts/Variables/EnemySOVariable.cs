using Dummerhuan.Combat;
using ScriptableObjectArchitecture;
using UnityEngine;

namespace Dummerhuan.Variables
{
	[CreateAssetMenu(
	    fileName = "EnemySOVariable.asset",
	    menuName = SOArchitecture_Utility.VARIABLE_SUBMENU + "Enemy",
	    order = 120)]
	public class EnemySOVariable : BaseVariable<EnemySO>
	{
	}
}