using Domain.Interfaces.InterfaceResource;
using Entities.Entities;
using Infrastructure.Repository.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repository.Repositories
{
    public class RepositoryResource : RepositoryGenerics<Resource>, IResource
    {
    }
}
