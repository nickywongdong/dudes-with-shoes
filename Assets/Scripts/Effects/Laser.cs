using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] LineRenderer _beam;
    [SerializeField] Transform _muzzlePoint;
    [SerializeField] float _maxLength;

    [SerializeField] ParticleSystem _muzzleParticles;
    [SerializeField] ParticleSystem _hitParticles;

    [SerializeField] float _damage;

    private void Awake()
    {
        _beam.enabled = false;
    }

    private void Activate() { 
        _beam.enabled = true;

        _muzzleParticles.Play();
        _hitParticles.Play();
    }

    private void Deactivate()
    { 
        _beam.enabled = false;

        _beam.SetPosition(0, _muzzlePoint.position);
        _beam.SetPosition(1, _muzzlePoint.position);

        _muzzleParticles.Stop();
        _hitParticles.Stop();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Activate();
        else if (Input.GetMouseButtonUp(0)) Deactivate();
    }

    private void FixedUpdate()
    {
        if (!_beam.enabled) return;

        var ray = new Ray(_muzzlePoint.position, _muzzlePoint.forward);
        var cast = Physics.Raycast(ray, out RaycastHit hit, _maxLength);
        var hitPosition = cast ? hit.point : _muzzlePoint.position + _muzzlePoint.forward * _maxLength;

        _beam.SetPosition(0, _muzzlePoint.position);
        _beam.SetPosition(1, hitPosition);

        _hitParticles.transform.position = hitPosition;

        if (cast && hit.collider.TryGetComponent<Damageable>(out var damageable)) {
            damageable.ApplyDamage(_damage * Time.deltaTime);
        }

    }
}
