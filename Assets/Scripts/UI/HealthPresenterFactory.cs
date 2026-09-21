using System.Collections.Generic;
using UnityEngine;

public class HealthPresenterFactory : MonoBehaviour
{
    [SerializeField] private List<HealthBarPair> _pairs;

    private readonly List<HealthPresenter> _presenters = new();

    private void OnEnable()
    {
        foreach (var pair in _pairs)
        {
            var presenter = new HealthPresenter(pair.Health, pair.Bar);
            _presenters.Add(presenter);
            presenter.Enable();
        }
    }

    private void OnDisable()
    {
        foreach (var presenter in _presenters)
            presenter.Disable();

        _presenters.Clear();
    }
}
