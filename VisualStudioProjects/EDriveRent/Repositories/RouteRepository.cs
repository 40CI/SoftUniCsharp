using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EDriveRent.Interfaces;
using EDriveRent.Models;

    namespace EDriveRent.Repositories
    {
        public class RouteRepository : IRepository<IRoute>
        {
            private readonly List<IRoute> _routes;

            public RouteRepository()
            {
                _routes = new List<IRoute>();
            }

            public void Add(IRoute route)
            {
                _routes.Add(route);
            }

            public void Remove(IRoute route)
            {
                _routes.Remove(route);
            }

            public IRoute Find(int id)
            {
                return _routes.FirstOrDefault(r => r.Id == id);
            }

            public IEnumerable<IRoute> GetAll()
            {
                return _routes;
            }

        public void AddModel(IRoute model)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(string identifier)
        {
            throw new NotImplementedException();
        }

        public IRoute FindById(string identifier)
        {
            throw new NotImplementedException();
        }

        IReadOnlyCollection<IRoute> IRepository<IRoute>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
    }


