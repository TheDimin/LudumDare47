using JimTheKiwifruit;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(CinemachineBrain))]
public class CameraManager : Singleton<CameraManager>
{
	public CinemachineBrain cinemachineBrain { get; private set; } = null;

	protected override void Awake()
	{
		base.Awake();
		cinemachineBrain = GetComponent<CinemachineBrain>();
	}
}