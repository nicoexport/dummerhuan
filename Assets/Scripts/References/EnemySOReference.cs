using Dummerhuan.Combat;
using Dummerhuan.Variables;
using ScriptableObjectArchitecture;

namespace Dummerhuan.References
{
	[System.Serializable]
	public sealed class EnemySOReference : BaseReference<EnemySO, EnemySOVariable>
	{
	    public EnemySOReference() : base() { }
	    public EnemySOReference(EnemySO value) : base(value) { }
	}
}