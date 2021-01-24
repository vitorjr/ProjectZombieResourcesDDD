using ApplicationApp.Interfaces;
using Domain.Interfaces.InterfaceResource;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationApp.OpenApp
{
    public class AppResource : InterfaceResourceApp
    {
        IResource _IResource;

        public AppResource(IResource IResource)
        {
            _IResource = IResource;
        }

        public async Task Add(Resource Objeto)
        {
            await _IResource.Add(Objeto);
        }

        public async Task Delete(Resource Objeto)
        {
            await _IResource.Delete(Objeto);
        }

        public async Task<Resource> GetEntityById(int Id)
        {
            return await _IResource.GetEntityById(Id);
        }

        public async Task<List<Resource>> List()
        {
            return await _IResource.List();
        }

        public async Task Update(Resource Objeto)
        {
            await _IResource.Update(Objeto);
        }
    }
}
