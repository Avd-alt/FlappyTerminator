using System;
using UnityEngine;

[RequireComponent(typeof(BirdCollisionHandler), typeof(BirdMover), typeof(ScoreCounter))]
public class Bird : MonoBehaviour
{
    private BirdMover _birdMover;
    private BirdCollisionHandler _handler;
    private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void Awake()
    {
        _handler = GetComponent<BirdCollisionHandler>();
        _birdMover = GetComponent<BirdMover>();
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    public void Reset()
    {
        _birdMover.Reset();
        _scoreCounter.Reset();
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if(interactable is Ground || interactable is Enemy || interactable is EnemyBullet)
        {
            GameOver?.Invoke();
        }
    }

}