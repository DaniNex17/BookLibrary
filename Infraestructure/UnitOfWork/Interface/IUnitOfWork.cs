using Infraestructure.Entity.Models;
using Infraestructure.Repository.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.UnitOfWork.Interface
{
    public interface IUnitOfWork
    {
        IRepository<UserEntity> UserRepository { get; }
        IRepository<RoleEntity> RoleRepository { get; }
        IRepository<PermissionEntity> PermissionRepository { get; }
        IRepository<PermissionTypeEntity> PermissionTypeRepository { get; }
        IRepository<RolePermissionEntity> RolePermissionRepository { get; }
        IRepository<AuthorEntity> AuthorRepository { get; }
        IRepository<BookEntity> BookRepository { get; }
        IRepository<EditorialEntity> EditorialRepository { get; }

        void Dispose();
        Task<int> Save();

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
