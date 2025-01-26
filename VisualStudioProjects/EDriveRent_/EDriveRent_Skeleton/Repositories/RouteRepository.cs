public class RouteRepository : IRepository<IRoute>
{
    private readonly List<IRoute> _routes = new List<IRoute>();

    public void AddModel(IRoute route)
    {
        _routes.Add(route);
    }

    public bool RemoveById(string identifier)
    {
        int routeId = int.Parse(identifier);
        var route = _routes.FirstOrDefault(r => r.RouteId == routeId);
        if (route != null)
        {
            _routes.Remove(route);
            return true;
        }
        return false;
    }

    public IRoute FindById(string identifier)
    {
        int routeId = int.Parse(identifier);
        return _routes.FirstOrDefault(r => r.RouteId == routeId);
    }

    public IReadOnlyCollection<IRoute> GetAll()
    {
        return _routes.AsReadOnly();
    }
}