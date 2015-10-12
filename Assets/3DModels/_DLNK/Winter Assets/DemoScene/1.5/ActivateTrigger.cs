using UnityEngine;
using System.Collections;

public class ActivateTrigger : MonoBehaviour {

	public Collider CharCollider;
	public bool ActivateObject = false;
	public GameObject ObjectEffect;
	public Animation AnimatorEffect;
	public AnimationClip AnimPlay;
	public AnimationClip AnimReset;
	public float TimeToReset;
	private float timer;
	private bool collide = false;

void	OnTriggerEnter(Collider col)
	{
		if(col.GetComponent<Collider>() == CharCollider)
		{
			AnimatorEffect.Play(AnimPlay.name);
			timer = 0f;
			if (!collide)
			{
			collide = true;
			Debug.Log("TrampActive");
			}
			if ((ActivateObject) && (ObjectEffect != null))
			{
				ObjectEffect.SetActive(true);
			}
		}
	}
void Update()
	{
		if (collide) 
		{
			timer = timer + Time.fixedDeltaTime;
			if (timer > TimeToReset)
			{
				AnimatorEffect.Play(AnimReset.name);
				timer=0f;
				collide=false;

				if ((ActivateObject) && (ObjectEffect != null))
				ObjectEffect.SetActive(false);
			}

		}
	}
}
